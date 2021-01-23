    List<string> columns = new List<string>();
            for (int i = 0; i < persister.PropertyNames.Count(); i++)
            {
                if (persister.GetPropertyColumnNames(i).Count() > 0)
                {
                    columns.Add(persister.GetPropertyColumnNames(i).ToList().First());
                }
            }
