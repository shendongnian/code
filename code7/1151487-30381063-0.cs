    Catalog cat = new Catalog();
            Table tableCustomer = new Table();
            Table tableAddresses = new Table();
            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Application.StartupPath
              + "\\Customers.mdb" + "; Jet OLEDB:Engine Type=5");
            ADODB.Connection con = new Connection();
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source="
                + Application.StartupPath + "\\Customers.mdb";
            
            try
            {
                con.Open(connString);
                cat.ActiveConnection = con;
                //Create the table Customer and it's fields. 
                tableCustomer.Name = "Customer";
                tableCustomer.Columns.Append("Customer_ID", ADOX.DataTypeEnum.adInteger);
                tableCustomer.Keys.Append("PrimaryKEy", KeyTypeEnum.adKeyPrimary, "Customer_ID");
                tableCustomer.Columns["Customer_ID"].ParentCatalog = cat;
                tableCustomer.Columns["Customer_ID"].Properties["AutoIncrement"].Value = true;
                tableCustomer.Columns.Append("Name", ADOX.DataTypeEnum.adVarWChar, 50);
                tableCustomer.Columns.Append("Email", ADOX.DataTypeEnum.adVarWChar, 50);
                tableCustomer.Columns.Append("TelNumber", ADOX.DataTypeEnum.adVarWChar, 32);
                tableCustomer.Columns.Append("Fax", ADOX.DataTypeEnum.adVarWChar, 32);
                tableCustomer.Columns.Append("AdressCounter", ADOX.DataTypeEnum.adSmallInt);
                tableAddresses.Name = "Addresses";
                tableAddresses.Columns.Append("Address_ID", ADOX.DataTypeEnum.adInteger);
                tableAddresses.Keys.Append("PrimaryKEy", KeyTypeEnum.adKeyPrimary, "Address_ID");
                tableAddresses.Columns["Address_ID"].ParentCatalog = cat;
                tableAddresses.Columns["Address_ID"].Properties["AutoIncrement"].Value = true;
                tableAddresses.Columns.Append("Customer_ID", ADOX.DataTypeEnum.adInteger);
                tableAddresses.Keys.Append("ForeignKey", KeyTypeEnum.adKeyForeign, "Customer_ID", "Customer", "Customer_ID");
                tableAddresses.Columns.Append("Street", ADOX.DataTypeEnum.adVarWChar, 50);
                tableAddresses.Columns.Append("PostalCode", ADOX.DataTypeEnum.adVarWChar, 10);
                tableAddresses.Columns.Append("City", ADOX.DataTypeEnum.adVarWChar, 50);
                //cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Application.StartupPath
                //    + "\\Customers.mdb" + "; Jet OLEDB:Engine Type=5");
                cat.Tables.Append(tableCustomer);
                cat.Tables.Append(tableAddresses);
                //Now Close the database
                //ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                if (con != null)
                    con.Close();
                result = true;
            }
