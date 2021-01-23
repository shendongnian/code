     void emp_id_generator(DataGridView dataGridView1)
            {
              if (dataGridView1 != null)
               {
                        int j = 6;  //this is what i want to increment
                 for (int count = 0; (count <= (dataGridView1.Rows.Count - 2)); count++)
                 {
                        Label l = new Label();
                        l.Text = "EmpID" + (j);
                        dataGridView1.Rows[count].Cells[0].Value = l.Text;
                         j=j+1;
                 }
              }
            }
