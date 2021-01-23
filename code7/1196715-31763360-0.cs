        rdb.CheckedChanged += new EventHandler(rdb_CheckedChanged);
        void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                // Check if this RadioButton belong to column 4th so it belong to the column group
                if (((RadioButton)sender).Name.Substring(((RadioButton)sender).Name.Length - 1) == "4")
                {
                    // Set Checked = false for all RadioButton in column 4 except this one
                }
                else
                {
                    // Set Checked = false for all RadioButton in this RadioButton's row 4 except this one
                }
        }
