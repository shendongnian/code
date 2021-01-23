    // Used to enable Json.NET to traverse an object hierarchy without actually writing any data.
    public class NullJsonWriter : JsonWriter
    {
        public NullJsonWriter()
            : base()
        {
        }
        public override void Flush()
        {
            // Do nothing.
        }
    }
    public class TypeInstanceCollector<T> : JsonConverter where T : class
    {
        readonly List<T> instanceList = new List<T>();
        readonly HashSet<T> instances = new HashSet<T>();
        public List<T> InstanceList { get { return instanceList; } }
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override bool CanRead { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            T instance = (T)value;
            if (!instances.Contains(instance))
            {
                instanceList.Add(instance);
                instances.Add(instance);
            }
            // It's necessary to write SOMETHING here.  Null suffices.
            writer.WriteNull();
        }
    }
    public class ADeserializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(A).IsAssignableFrom(objectType);
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            if (obj == null)
                return existingValue;
            A a;
            var refId = (string)obj["$ref"];
            if (refId != null)
            {
                a = (A)serializer.ReferenceResolver.ResolveReference(serializer, refId);
                if (a != null)
                    return a;
            }
            a = ((A)existingValue) ?? new A();
            var items = obj["Items"];
            obj.Remove("Items");
            // Populate properties other than the items, if any
            // This also updates the ReferenceResolver table.
            using (var objReader = obj.CreateReader())
                serializer.Populate(objReader, a);
            // Populate properties of the B items, if any
            if (items != null)
            {
                if (items.Type != JTokenType.Array)
                    throw new JsonSerializationException("Items were not an array");
                var itemsArray = (JArray)items;
                if (a.Items.Count() < itemsArray.Count)
                    throw new JsonSerializationException("too few items constructucted"); // Item counts must match
                foreach (var pair in a.Items.Zip(itemsArray, (b, o) => new { ItemB = b, JObj = o }))
                {
    #if false
                    // If your B class has NO properties to deserialize, do this
                    var id = (string)pair.JObj["$id"];
                    if (id != null)
                        serializer.ReferenceResolver.AddReference(serializer, id, pair.ItemB);
    #else
                    // If your B class HAS SOME properties to deserialize, do this
                    using (var objReader = pair.JObj.CreateReader())
                    {
                        // Again, Populate also updates the ReferenceResolver table
                        serializer.Populate(objReader, pair.ItemB);
                    }
    #endif
                }
            }
            return a;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class RootProxy<TRoot, TTableItem>
    {
        [JsonProperty("table", Order = 1)]
        public List<TTableItem> Table { get; set; }
        [JsonProperty("data", Order = 2)]
        public TRoot Data { get; set; }
    }
    public class TestClass
    {
        public static string Serialize(MainClass main)
        {
            // First, collect all instances of A 
            var collector = new TypeInstanceCollector<A>();
            var collectionSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, Converters = new JsonConverter[] { collector } };
            using (var jsonWriter = new NullJsonWriter())
            {
                JsonSerializer.CreateDefault(collectionSettings).Serialize(jsonWriter, main);
            }
            // Now serialize a proxt class with the collected instances of A at the beginning, to establish reference ids for all instances of B.
            var proxy = new RootProxy<MainClass, A> { Data = main, Table = collector.InstanceList };
            var serializationSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            return JsonConvert.SerializeObject(proxy, Formatting.Indented, serializationSettings);
        }
        public static MainClass Deserialize(string json)
        {
            var serializationSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, Converters = new JsonConverter[] { new ADeserializer() } };
            var proxy = JsonConvert.DeserializeObject<RootProxy<MainClass, A>>(json, serializationSettings);
            return proxy.Data;
        }
        static IEnumerable<A> GetAllA(MainClass main)
        {
            // For testing.  In your case apparently you can't do this manually.
            if (main.A1 != null)
                yield return main.A1;
            if (main.A2 != null)
                yield return main.A2;
            if (main.MidClass != null && main.MidClass.AnotherA != null)
                yield return main.MidClass.AnotherA;
        }
        static IEnumerable<B> GetAllB(MainClass main)
        {
            return GetAllA(main).SelectMany(a => a.Items);
        }
        public static void Test()
        {
            var main = new MainClass();
            main.A1.SomeProperty = "main.A1.SomeProperty";
            main.A1.SomeOtherProperty = "main.A1.SomeOtherProperty";
            main.A2.SomeProperty = "main.A2.SomeProperty";
            main.A2.SomeOtherProperty = "main.A2.SomeOtherProperty";
            main.MidClass.AnotherA.SomeProperty = "main.MidClass.AnotherA.SomeProperty";
            main.MidClass.AnotherA.SomeOtherProperty = "main.MidClass.AnotherA.SomeOtherProperty";
            main.ListOfB = GetAllB(main).Reverse().ToList();
            var json = Serialize(main);
            var main2 = Deserialize(json);
            var json2 = Serialize(main2);
            foreach (var b in main2.ListOfB)
                Debug.Assert(GetAllB(main2).Contains(b)); // No assert
            Debug.Assert(json == json2); // No assert
            Debug.Assert(main.ListOfB.Select(b => b.Index).SequenceEqual(main2.ListOfB.Select(b => b.Index))); // No assert
            Debug.Assert(GetAllA(main).Select(a => a.SomeProperty + a.SomeOtherProperty).SequenceEqual(GetAllA(main2).Select(a => a.SomeProperty + a.SomeOtherProperty))); // No assert
        }
    }
