    public class CheckboxModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
    public class MainModel
    {
        public List<CheckboxModel> CheckBoxes { get; set; }
    }
