    [DataContract(IsReference = true, Namespace="")]
    public class Item
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Item SubItem { get; set; }
    }
    public class TestClass
    {
        public static void TestSimple()
        {
            var item1 = new Item { Id = 1 };
            var item2 = new Item { Id = 2 };
            item1.SubItem = item2;
            var xml = DataContractSerializerHelper.GetXml(new[] { item1, item2 });
            Debug.WriteLine(xml);
        }
    }
