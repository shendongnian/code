    string[] fileDataField= new string[]{"Mon","Thu","Wed","yh","Friday","sat","Sun","COOL"};
                     int  count = fileDataField.Count();
                     count = count - 1;
                  for (int i = 0; i <= count; i++)
                  {
                      DataGridViewTextBoxColumn columnDataGridTextBox = new DataGridViewTextBoxColumn();
                      columnDataGridTextBox.Width = 100;
                      dataGridView2.Columns.Add(columnDataGridTextBox);
                     }
                      dataGridView2.Rows.Add(fileDataField);
