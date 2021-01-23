    if (comboBox1.SelectedItem == "Wages")
                {
                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].Name = "StoreLoc";
                    dataGridView1.Columns[1].Name = "Month";
                    dataGridView1.Columns[2].Name = "Value";
                }
                else if (comboBox1.SelectedItem == "Sales")
                {
                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].Name = "StoreName";
                    dataGridView1.Columns[1].Name = "StoreType";
                    dataGridView1.Columns[2].Name = "Value";
                }
