    public class B
    {
        public int Index { get; set; }
    }
    public class A
    {
        readonly B [] items; // A private read-only array that is never changed.
        [JsonConstructor]
        public A(IEnumerable<B> Items, string SomeProperty)
        {
            this.items = (Items ?? Enumerable.Empty<B>()).ToArray();
            this.SomeProperty = SomeProperty;
        }
        public IEnumerable<B> Items
        {
            get
            {
                foreach (var b in items)
                    yield return b;
            }
        }
        [JsonIgnore]
        public int Count { get { return items.Length; } }
        public B GetItem(int index)
        {
            return items[index];
        }
        public string SomeProperty { get; set; }
        public string SomeOtherProperty { get; set; }
    }
    public class TestClass
    {
        public A A { get; set; }
        public List<B> ListOfB { get; set; }
        public static void Test()
        {
            var a = new A(new B[] { new B { Index = 101 }, new B { Index = 102 } }, "foobar") { SomeOtherProperty = "something else" };
            var test = new TestClass { A = a, ListOfB = a.Items.Reverse().ToList() };
            var settings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            var json = JsonConvert.SerializeObject(test, Formatting.Indented, settings);
            Debug.WriteLine(json);
            var test2 = JsonConvert.DeserializeObject<TestClass>(json, settings);
            // Assert that pointers in "ListOfB" are equal to pointers in A.Items
            Debug.Assert(test2.ListOfB.All(i2 => test2.A.Items.Contains(i2, new ReferenceEqualityComparer<B>())));
            // Assert deserialized data is the same as the original data.
            Debug.Assert(test2.A.SomeProperty == test.A.SomeProperty);
            Debug.Assert(test2.A.SomeOtherProperty == test.A.SomeOtherProperty);
            Debug.Assert(test2.A.Items.Select(i => i.Index).SequenceEqual(test.A.Items.Select(i => i.Index)));
            var json2 = JsonConvert.SerializeObject(test2, Formatting.Indented, settings);
            Debug.WriteLine(json2);
            Debug.Assert(json2 == json);
        }
    }
