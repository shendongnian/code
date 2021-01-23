    public class MyFirstData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public bool Filter(string filterText)
        {
            return Id.ToString() == filterText || Name.Contains(filterText);
        }
    }
