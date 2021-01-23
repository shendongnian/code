    List<YourClass> list = new List<YourClass>();
    
    YourClass yc = new YourClass();
    yc.Column1 = "1";
    yc.Column2 = "5";
    
    list.Add(yc);
    dataGridView1.DataSource = list;
    
    public class YourClass
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
