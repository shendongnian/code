            var list = new List<Dictionary<string, object>>();
            // Build a dictionary entry using a dictionary initializer: https://msdn.microsoft.com/en-us/library/bb531208.aspx
            list.Add(new Dictionary<string, object> { { "ID", 1 }, {"Product", "Pie"}, {"Days", 1}, {"QTY", 65} });
            // Build a dictionary entry incrementally
            // See https://msdn.microsoft.com/en-us/library/xfhwa508%28v=vs.110%29.aspx
            var dict = new Dictionary<string, object>();
            dict["ID"] = 2;
            dict["Product"] = "Melons";
            dict["Days"] = 5;
            dict["QTY"] = 12;
            list.Add(dict);
            Console.WriteLine(JsonConvert.SerializeObject(list, Formatting.Indented));
            Console.WriteLine(new JavaScriptSerializer().Serialize(list));
