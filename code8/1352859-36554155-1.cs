            string[] values = 
                {
                    "TR42X2330789",
                    "TR42X2330790",
                    "TR42X2330791",
                    "TR51C0613938",
                    "TR51C0613939",
                    "TR51C0613940",
                    "TR51C0613941",
                    "TR51C0613942",
                    "TR52X4224749"
                };
            Dictionary<string, List<string>> grouppedValues = values.GroupBy(v => 
                        new string(v.Take(9).ToArray()),   // key - first 9 chars
                             v => v)                       // value
                                .ToDictionary(g => g.Key, g => g.ToList());
            foreach (var item in grouppedValues)
            {
                Console.WriteLine(item.Key + "   " + item.Value.Count);
            }
