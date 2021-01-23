            var myEmployees = new Employees();
            var properties = myEmployees.GetType().GetProperties();
            foreach (var field in properties)
            {
                field.SetValue(myEmployees, "NewValue");
            }
            // Print all field's values
            foreach (var item in properties)
            {
                Console.WriteLine(item.GetValue(myEmployees));
            }
