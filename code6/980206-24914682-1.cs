    public interface IDropDownItem
    {
        int ID { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        bool IsActive { get; set; }
    }
    
    public class Division : IDropDownItem
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    
    public List<DropDownItem> GetDropDown<T>(bool isActive, bool hasPrompt, IEnumerable<T> input) where T : IDropDownItem
    {
        var dropDown = new List<DropDownItem>();
        if (hasPrompt)
        {
           dropDown.Add(new DropDownItem() { ID = 0, Description = "Select one", Name = "SelectOne", IsActive = false });
        }
    
        foreach (var item in input)
        {
           DropDownItem di = new DropDownItem { ID = item.ID, Description = item.Description, Name = item.Name, IsActive = item.IsActive };
           dropDown.Add(di);
        }
    
        return dropDown;
    }
