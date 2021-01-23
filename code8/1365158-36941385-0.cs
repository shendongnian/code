     public static DataTable GetList(string site, string listname)
        {
            ClientContext ctx = new ClientContext(site);
            List lst = ctx.Web.Lists.GetByTitle(listname);
            CamlQuery cq = CamlQuery.CreateAllItemsQuery();
            ListItemCollection lic = lst.GetItems(cq);
            ctx.Load(lic);
            ctx.ExecuteQuery();
            DataTable dt = new DataTable();
            foreach (var field in lic[0].FieldValues.Keys)
            {
                dt.Columns.Add(field);
            }
            foreach (var item in lic)
            {
                DataRow dr = dt.NewRow();
                foreach (var obj in item.FieldValues)
                {
                    if (obj.Value != null)
                    {
                        string type = obj.Value.GetType().FullName;
                        if (type == "Microsoft.SharePoint.Client.FieldLookupValue")
                        {
                            dr[obj.Key] = ((FieldLookupValue)obj.Value).LookupValue;
                        }
                        else if (type == "Microsoft.SharePoint.Client.FieldUserValue")
                        {
                            dr[obj.Key] = ((FieldUserValue)obj.Value).LookupValue;
                        }
                        else
                        {
                            dr[obj.Key] = obj.Value;
                        }
                    }
                    else
                    {
                        dr[obj.Key] = null;
                    }
                }
                dt.Rows.Add(dr);
            }
            GetList = dt;
            return GetList;
        }
