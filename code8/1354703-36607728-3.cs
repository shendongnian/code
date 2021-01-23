    public class MyViewModel
    {
        // Name of field MUST match name of field in EF/ORM...
        public string DisplayName { get; set; }
    }
    public IEnumerable<string> GetAllManagers()
    {
        var displayList = context.OWF_ManagerRelationship
            .Where(m => m.IsActive.Value == true)
            .Project()
            .To<MyViewModel>()
            .ToList();
        IEnumerable<string> managers = displayList.Select(a => a.DisplayName).ToList();
        return managers;
    }
