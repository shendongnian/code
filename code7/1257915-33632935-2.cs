    public class MoveItemValues
    {
        public string Pile;
        public Int64 Id;
    }
    
    public class MoveItemRequestValues
    {
        public IList<MoveItemValues> ItemData;
    
        public MoveItemRequestValues()
        {
            ItemData = new List<MoveItemValues>();
        }
    }
    
    static void MoveItem(Int64 itemId, string pile)
    {
        string moveItemResponse;
        MoveItemRequestValues bodyContent = new MoveItemRequestValues();
        bodyContent.ItemData = new List<MoveItemValues>()
        {
            new MoveItemValues {Pile = pile, Id = itemId}
        };
        var camelCaseFormatter = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        string jsonContent = JsonConvert.SerializeObject(bodyContent, camelCaseFormatter);
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonContent);
        Console.WriteLine(jsonContent);
    }
    
    static void Main(string[] args)
    {
        MoveItem(100997087277, "trade");
        Console.ReadLine();
    }
