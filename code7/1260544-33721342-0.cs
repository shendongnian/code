            // Creating columns and setting it readonly
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].HeaderText = "Colour";
            dataGridView1.Columns[1].Name = "Colour";
            dataGridView1.Columns[2].HeaderText = "Code";
            dataGridView1.Columns[2].Name = "Code";
            dataGridView1.Columns[3].HeaderText = "Length";
            dataGridView1.Columns[3].Name = "Length";
            dataGridView1.Columns[4].HeaderText = "Quantity";
            dataGridView1.Columns[4].Name = "Quantity";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Refresh();
    
            //Now somewhere other in code populating them this way
            int Row = 0;
            dataGridView1.Rows.Add();
            Row = dataGridView1.Rows.Count - 2;
            dataGridView1[0, Row].Value = Convert.ToString(CBName.SelectedValue);
            dataGridView1[1, Row].Value = Convert.ToString(CBColour.SelectedValue);
            dataGridView1[2, Row].Value = Convert.ToString(CBCode.SelectedValue);
            dataGridView1[3, Row].Value = Convert.ToString(CBLength.SelectedValue);
            dataGridView1[4, Row].Value = Convert.ToString(txtQuantity.Text);
            dataGridView1[5, Row].Value = Convert.ToString(inven.Id);
            dataGridView1.Refresh();
