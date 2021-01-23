    public static DataTable ToDataTable<T>(IList<T> data)
            {
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;
            }
    private void AddNewRowToGrid()
            {
                DataTable dt = (DataTable) Session["ss"];
                DataRow dr = null;
                DataRow newBlankRow1 = dt.NewRow();
                dt.Rows.Add(newBlankRow1);
                grid2.DataSource = dt;
                grid2.DataBind();
    
                Session["ss"] = dt;
            }
