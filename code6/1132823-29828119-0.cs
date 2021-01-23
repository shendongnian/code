    var names = new List<string>(); 
    if (isNewName())
        names.Add("Name");
    if (isNewLove())
        names.Add("Love");
    var op = String.Format("{0} {1} updated.", String.Join(" and ", names), names.Count == 1 ? "is" : "are");
