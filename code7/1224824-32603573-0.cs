            var list = new List<Dictionary<string, object>>();
            list.Add(new Dictionary<string, object> { { "ID", 1 }, {"Product", "Pie"}, {"Days", 1}, {"QTY", 65} }); // Using a dictionary initializer: https://msdn.microsoft.com/en-us/library/bb531208.aspx
            list.Add(new Dictionary<string, object> { { "ID", 2 }, { "Product", "Melons" }, { "Days", 5 }, { "QTY", 12 } });
            Console.WriteLine(JsonConvert.SerializeObject(list, Formatting.Indented));
            Console.WriteLine(new JavaScriptSerializer().Serialize(list));
