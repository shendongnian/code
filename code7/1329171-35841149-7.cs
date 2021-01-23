    //Fill the Grid
            for (int i = 0; i < newList.Count; i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());
                
                dataGridView1.Rows[i].Cells[2].Value = newList[i].DateTime.ToString("dd.MM.yyyy");
                
                 if (!string.IsNullOrEmpty(newList[i].Name)) //=> Is not a Header
                {
                    dataGridView1.Rows[i].Cells[2].Value = newList[i].DateTime.ToString("dd.MM.yyyy");
                    dataGridView1.Rows[i].Cells[0].Value = newList[i].Name;
                    dataGridView1.Rows[i].Cells[1].Value = newList[i].AppointmentType;
                    dataGridView1.Rows[i].Cells[3].Value = newList[i].DateTime.ToString("HH:mm:ss");
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = newList[i].DateTime.ToString("dddd dd.MM.yyyy", new CultureInfo("en-GB"));
                    dataGridView1.Rows[i].Cells[0].Value = newList[i].Name = null;
                    dataGridView1.Rows[i].Cells[1].Value = newList[i].AppointmentType = null;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
