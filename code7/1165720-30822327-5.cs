    var list = new List<object>();
    list.Add(new { Name = "First Name", IsActive = true });
    list.Add(new { Name = "Second Name", IsActive = true });
    list.Add(new { Name = "Third Name", IsActive = false });
    list.Add(new { Name = "Fourth Name", IsActive = true });
    list.Add(new { Name = "Fifth Name", IsActive = false });
    list.Add(new { Name = "Sixth Name", IsActive = true });
    list.Add(new { Name = "Seventh Name", IsActive = true });
    DataContext = new { List = list };
