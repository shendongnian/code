    string json = "[{ \"PrintId\":10,\"Header\":\"header\",\"TC\":\"tc\",\"CompanyRef\":\"00000000-0000-0000-0000-000000000000\"}"
                + ",{ \"PrintId\":20,\"Header\":\"header2\",\"TC\":\"tc2\",\"CompanyRef\":\"00000000-0000-0000-0000-000000000000\"}]";
    var objs = JsonConvert.DeserializeObject<List<Print>>(json);
    
    //The loop is only for testing. Replace it with your code.
    foreach(Print p in objs){
    	Console.WriteLine("PrintId: " + p.PrintId);
    	Console.WriteLine("Header: " + p.Header);
    	Console.WriteLine("TC: " + p.TC);
    	Console.WriteLine("CompanyRef: " + p.CompanyRef);
    	Console.WriteLine("==============================");
    }
    public class Print
    {
        public int PrintId { get; set; }
        public string Header { get; set; }
        public string TC { get; set; }
        public string CompanyRef { get; set; }
    }
