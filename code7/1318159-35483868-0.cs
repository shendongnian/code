    public class CollectionClearingContractResolver : DefaultContractResolver
    {
        protected override JsonArrayContract CreateArrayContract(Type objectType)
        {
            var c = base.CreateArrayContract(objectType);
            c.OnDeserializingCallbacks.Add((obj, streamingContext) =>
            {
                if (obj is IList)
                    ((IList)obj).Clear();
            });
            return c;
        }
    }
    
    ...
    
    public class Test {
        public List<int> List { get; private set; }
        public Test() {
            List = new List<int>();
        }
    }  
    
    ...
    
    var myObj = new Test();
    myObj.List.AddRange(new[] {1,2,3});
    var listReference = myObj.List;    
    JsonConvert.PopulateObject("{ List: [4, 5, 6] }", myObj, 
        new JsonSerializerSettings {
            ContractResolver = new CollectionClearingContractResolver(),
        });
    
    myObj.List.ShouldEqual(listReference); // didn't recreate list
    myObj.List.Count.ShouldEqual(3);
    myObj.List.SequenceEqual(new[] { 4, 5, 6}).ShouldBeTrue();
