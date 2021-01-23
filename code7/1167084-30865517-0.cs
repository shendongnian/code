            List<RootObject> obj = JsonConvert.DeserializeObject<List<RootObject>>(responseText);
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in obj)
            {
                foreach (var code in nation_code)
                {
                    if (code.Equals(item.League))
                    {
                        comboSource.Add(item.Caption, item.Links.Teams.href);
    
                    }
                }
            }
            League.ValueMember = "Value";
            League.DisplayMember = "Key";
            League.DataSource = comboSource;
