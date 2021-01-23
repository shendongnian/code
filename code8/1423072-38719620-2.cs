    public static string ConvertDatadttoString(string appName = "")
    {
        var columnNames = "Name,County";
        var employees = CreateEmployeesTable();
        var sample = new List<SampleClass>
        {
            new SampleClass()
            {
                columns = columnNames.Split(',').Select(x=> new SampleItem
                {
                    title = x
                }),
                data = employees.AsEnumerable().Select(row=> new List<string>
                {
                    row.Field<string>("EmployeeName"),
                    row.Field<string>("Company")
                })
            }
        };
        var serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(sample);
        return json;
    }
