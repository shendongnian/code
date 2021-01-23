            var lic = new ListItemCollection();
            for (var i = 0; i < 5; i++)
            {
                var fieldName = string.Format("field {0}", i);
                var fieldValue = string.Format("Value {0}", i);
                lic.Add(new ListItem(fieldName, fieldValue));
            }
            var allowedFields = new List<string>
            {
                "field 1",
                "field 4"
            };
            var listItems = lic.Cast<ListItem>().Where(i => allowedFields.Contains(i.Text));
