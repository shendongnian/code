            if (data[0].GetType().IsArray)
            {
                Console.WriteLine(string.Join(",", ((Array)data[0]).Cast<object>()));
            }
            else
            {
                Console.WriteLine(data[0]);
            }
