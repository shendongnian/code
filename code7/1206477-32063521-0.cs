     DataTable dt=new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("ph_NO");
            dt.Rows.Add(new object[] { "sonu", 213123 });
            dt.Rows.Add(new object[] { "abhay", 123411});
            dt.Rows.Add(new object[] { "John", 234123 });
            dataGridView1.DataSource = dt;            
           listBox1.DataBindings.Add(new Binding("DataSource", dataGridView1,"DataSource"));
           listBox1.DisplayMember = "Name";
