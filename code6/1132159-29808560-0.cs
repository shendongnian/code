    var listTwo = connection.Query<dynamic>("SELECT name, value FROM Example")
        .Select(x => new ExampleDbf 
            { 
                Value = x.value,  
                Name = System.Text.Encoding.ASCII.GetString((byte[])x.name).Trim()
            }).ToList();
