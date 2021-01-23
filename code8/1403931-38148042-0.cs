            foreach (MyViewModel item in lst_Host_VM)
            {
                DataRow row = table.NewRow();
                var test = typeof(MyViewModel).GetProperties()
                    .Where(p => p.IsDefined(typeof(DisplayAttribute), false))
                    .Select(p => new
                    {
                        PropertyName = p.Name,
                        p.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().Name,
                        Value = p.GetValue(item)
                    });
                foreach (var itm in test)
                {
                    row[itm.Name] = itm.Value;
                }
                table.Rows.Add(row);
            }
