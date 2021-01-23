        string sql = "Select preview, text from Covers;";
        ..
        ..
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        // either simply set this to true or..
        dataGridView1.AutoGenerateColumns = false;
        // add all columns.. 
        DataGridViewImageColumn dvgic = new DataGridViewImageColumn();
        // setting their names
        dvgic.Name = "preview";
        dvgic.HeaderText = "Preview";
        // and relating them to the data source fields..
        dvgic.DataPropertyName = "preview";
        dataGridView1.Columns.Add(dvgic);
        dataGridView1.Columns.Add("text", "Text");
        dataGridView1.Columns["text"].DataPropertyName = "text";
                
        dataGridView1.DataSource = ds.Tables[0];
