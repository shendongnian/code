    var duplicateValues = (from row in dt.AsEnumerable()
                       orderby row.Field<string>("Id")
                       select new DuplicateObject
                       {
                           Id = row.Field<string>("Id"),
                           Name = row.Field<string>("Name"),
                           Skill = row.Field<string>("Skill")
                       }).Distinct(new DuplicateObjectComparer()).ToList();
    string dupValue = string.Empty;
    foreach (var dup in duplicateValues)
    {
    dupValue = dup.Id + " - " + dup.Name + " - " + dup.Skill;
    Console.WriteLine("Duplicate entry:" + dupValue);
    }
    if (duplicateValues.Count == 0)
    Console.WriteLine("No duplicate entry");
    // Supporting classes
    // Gives a strongly type class from the Linq query    
    public class DuplicateObject
    {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Skill { get; set; }
    }
