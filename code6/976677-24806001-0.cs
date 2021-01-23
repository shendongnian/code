    // Select string properties
    var columns = typeof(Entity).GetProperties().Where(prop => prop.PropertyType == typeof(string)).Select(c => c.Name + " == @0");
    // Aggregate
    var queryString = string.Join(" || ", columns);
    // Query with Linq Dynamic
    var query = db.Entities.Where(queryString, "MyString");
