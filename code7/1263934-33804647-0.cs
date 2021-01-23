            string str = "file_{AAA}_{BBB}.xml";
            var regex = new Regex("{.*?}");
            var matches = regex.Matches(str);
            List<string> result = new List<string>();
            foreach (var item in matches)
            {
                result.Add(item.ToString().Replace("{", "").Replace("}", ""));
            }
