    public class Print
    {
        public int PrintId { get; set; }
        public string Header { get; set; }
        public string TC { get; set; }
        public string CompanyRef { get; set; }
    }
    Print printObj = JsonConvert.DeserializeObject<Print>(yourJson);
    printObj.PrintId = //...
