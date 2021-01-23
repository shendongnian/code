    class EquipmentItem
    {
        public int id { get; set; }
        public string slot { get; set; }
        public List<int> upgrades { get; set; }
    }
    class Personnages
    {
        public string name { get; set; }
        public string race { get; set; }
        public string gender { get; set; }
        public string profession { get; set; }
        public string level { get; set; }
        public List<EquipmentItem> equipment { get; set; }
    }
    Personnages perso = JsonConvert.DeserializeObject<Personnages>(responseString);
