    foreach (var control in <YourForm>.Controls)
            {
                var props = control.GetType().GetProperties();
                foreach (var propertyInfo in props.Where(p=>p.PropertyType == typeof(string)))
                {
                    Console.WriteLine("Name: {0} - Value: {1}", propertyInfo.Name, propertyInfo.GetValue(control, null));
                }
            }
