    private void Form1_Load(object sender, EventArgs e)
    {
        List<DimZone> source = new List<DimZone>();
        DimZone curZone = new DimZone() { Zone_Key = 1, Zone_ID = 11, Facility_Key = 111, Zone_Name = "1111", Zone_Type = "11111" };
        source.Add(curZone);
        curZone = new DimZone() { Zone_Key = 2, Zone_ID = 22, Facility_Key = 222, Zone_Name = "2222", Zone_Type = "22222" };
        source.Add(curZone);
    
        zoneListBox.DisplayMember = "Facility_Key";
        zoneListBox.DataSource = source;
    }
    
    public class DimZone
    {
        public int Zone_Key { get; set; }
        public int Zone_ID { get; set; }
        public int Facility_Key { get; set; }
        public string Zone_Name { get; set; }
        public string Zone_Type { get; set; }
    }
