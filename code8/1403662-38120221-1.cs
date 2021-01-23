    public class MyModel
    {
        [Key]        
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CheckBoxListItem> ChkList { get; set; }
    }
