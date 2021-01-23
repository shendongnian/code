    dynamic[] data =
    {
        new { A = "A1", B = "B1", C = "C1", D = "D1", E = "E1", F = "F1" },
        new { A = "A1", B = "B1", C = "C1", D = "D1", E = "E1", F = "F1", G = "G1" },
        new { A = "A1", B = "B1", C = "C1", D = "D1", E = "E1", H = "H1", I = "I1" }
    };
    var keyProperties = new[] { "A", "B", "C", "D", "E" };
    var newList = data.GroupBy(row => new { row.A, row.B, row.C, row.D, row.E }).Select(
        y => new
             {
                 A = y.Key.A,
                 B = y.Key.B,
                 C = y.Key.C,
                 D = y.Key.D,
                 E = y.Key.E,
                 Children = y.Select(
                     item =>
                     {
                         IEnumerable<dynamic> itemProps = item.GetType().GetProperties();
                         List<dynamic> properties =
                             itemProps.Where(p => !Enumerable.Contains(keyProperties, p.Name)).ToList();
                         var result = new ExpandoObject();
                         foreach (var property in properties)
                         {
                             var value = property.GetValue(item, null);
                             if (value != null)
                             {
                                 ((IDictionary<string, object>)result).Add(property.Name, value);
                             }
                         }
                         return result;
                     }).ToList()
             });
    var str = JsonConvert.SerializeObject(newList);
