            public string GetInformation(int id)
            {
                var list = Session["oud"] as List<string>;
    
                if (list == null)
                {
                    list = new List<string>();
                    Session["oud"] = list;
                }
    
                list.Add(id.ToString());
                
                return string.Join(", ", list);
            }
