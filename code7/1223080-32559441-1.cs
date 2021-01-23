        void Form1_Load(object sender, EventArgs e)
        {
            //load your datatable here
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Name";
            comboBox1.Items.Add(new { ID = 0, Name = "Select" });
            foreach (DataRow a in dt.Rows)
                comboBox1.Items.Add(new { ID = a["ID"], Name = a["Name"] });
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDown += new EventHandler(comboBox1_DropDown);
            comboBox1.DropDownClosed += new EventHandler(comboBox1_DropDownClosed);
        }
        void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains(new { ID = 0, Name = "Select" }))
            {
                comboBox1.Items.Insert(0, new { ID = 0, Name = "Select" });
                comboBox1.SelectedIndex = 0;
            }
        }
        void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(new { ID = 0, Name = "Select" }))
                comboBox1.Items.Remove(new { ID = 0, Name = "Select" });
        }
