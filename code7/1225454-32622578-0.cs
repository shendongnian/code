    private void SerializeDataSet()
            {
                // Creates a DataSet for user info
                DataSet vault = new DataSet("vault");
                DataTable table_users = new DataTable("users");
                table_users.Columns.Add("last_name", typeof(string));
                table_users.Columns.Add("first_name", typeof(string));
                table_users.Columns.Add("birthdate", typeof(DateTime));
                table_users.Columns.Add("role", typeof(int));
                // adds table
                vault.Tables.Add(table_users);
                table_users.Rows.Add(new object[] { "Doe", "John", DateTime.Parse("10/15/1975"), 0 });
                // serialized table
                string filename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Resources) + "Vault_Tec_storage";
                vault.WriteXml(filename);
            }
