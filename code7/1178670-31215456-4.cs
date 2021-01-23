            string[] name = new string[] { "John", "Chip" };
            string[] lastname = new string[] { "Coleman", "Dale" };
            string[] title = new string[] { "Mr", "Dr" };
            string[] profession = new string[] { "Coder", "Doctor" };
            var employees2 = new { Employees = Enumerable.Range(0, name.Length).Select(i => new { title = title[i], name = name[i], lastname = lastname[i], profession = profession[i] }) };
            var json2 = JsonConvert.SerializeObject(employees2, Formatting.Indented);
            Debug.WriteLine(json2);
