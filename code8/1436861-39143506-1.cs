            DataSet ds = new DataSet(); //new dataset instance
            DataTable dtbl = new DataTable("Your Parent TableName");  //two new instanced tables
            DataTable dtbl2 = new DataTable("Your Child TableName");
            sdata.Fill(dtbl);  //fill both tables with each query data
            sdata2.Fill(dtbl2);
            ds.Tables.Add(dtbl); //Add those tables to DataSet
            ds.Tables.Add(dtbl2);
            ds.Relations.Add("Your Relation Name",dtbl.Columns["id"], dtbl2.Columns["id_prov_comp"]);
            //or
            //ds.Relations.Add(ds.Tables["dtbl"].Columns["id"], ds.Tables["dtbl2"].Columns["id_prov_comp"]);
            ds.AcceptChanges();
