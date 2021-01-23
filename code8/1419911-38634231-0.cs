        DataTable custMsrDT = this.MeasureDB.getMsrCustomerDT();
        using (SqlConnection connection = new SqlConnection(LocalDB.connStringLocalDB))
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT id, crm_customer_id, jb_customer_id, fname, lname, phone, alt_phone, email, street_address, unit_number, neighborhood, city, state, zip, county FROM dbo.customer;", connection);
            DataSet localDS = new DataSet();
            da.Fill(localDS, "customer");
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            localDS.Tables["customer"].RowChanged += new System.Data.DataRowChangeEventHandler(Row_Changed);
            //localDS.Tables["customer"].Merge(custMsrDT, true, MissingSchemaAction.Add);
            using (DataTableReader changeReader = new DataTableReader(custMsrDT))
            {
                localDS.Tables["customer"].Load(changeReader, LoadOption.Upsert);
            }
            PrintColumns(localDS.Tables["customer"]);
            DisplayRowState(localDS.Tables["customer"]);
            da.Update(localDS, "customer")
