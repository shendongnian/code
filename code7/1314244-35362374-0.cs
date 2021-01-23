     var value = pm.TableHeaders;
            
            List<string> nameFilters = new List<string>()
            {
                "Name",
                "Name2",
            };
            List<string> text = value.Select(x => x.Text).Where(columnName => columnName != "").ToList();
            
            return nameFilters.SequenceEqual(text);
