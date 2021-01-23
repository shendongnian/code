        private int count = 1;
        private void nextQuestion_Click(object sender, EventArgs e)
        {
            //int test = dataGridView1.Rows.Count - 1;
            //MessageBox.Show(dataGridView1.Rows.Count.ToString() + test);
            if (count < (dataGridView1.Rows.Count - 1))
            {
                int question = count + 1;
                questionNumber.Text = "Q" + question;
                iqquestion.Text = dataGridView1.Rows[count].Cells[2].Value.ToString();
                if (dataGridView1.Rows[count].Cells[3].Value != DBNull.Value) { radioButton1.Text = dataGridView1.Rows[count].Cells[3].Value.ToString(); radioButton1.Show(); }
                else { radioButton1.Hide(); }
                if (dataGridView1.Rows[count].Cells[4].Value != DBNull.Value) { radioButton2.Text = dataGridView1.Rows[count].Cells[4].Value.ToString(); radioButton2.Show(); }
                else { radioButton2.Hide(); }
                if (dataGridView1.Rows[count].Cells[5].Value != DBNull.Value) { radioButton3.Text = dataGridView1.Rows[count].Cells[5].Value.ToString(); radioButton3.Show(); }
                else { radioButton3.Hide(); }
                if (dataGridView1.Rows[count].Cells[6].Value != DBNull.Value) { radioButton4.Text = dataGridView1.Rows[count].Cells[6].Value.ToString(); radioButton4.Show(); }
                else { radioButton4.Hide(); }
                if (dataGridView1.Rows[count].Cells[7].Value != DBNull.Value) { radioButton5.Text = dataGridView1.Rows[count].Cells[7].Value.ToString(); radioButton5.Show(); }
                else { radioButton5.Hide(); }
                correctanswer.Text = dataGridView1.Rows[count].Cells[8].Value.ToString();
                instructions.Text = dataGridView1.Rows[count].Cells[9].Value.ToString();
                correctInstructions.Text = instructions.Text;
                count++;
            }
            if (count == (dataGridView1.Rows.Count - 1))
            {
                var homeform = new Home();
                homeform.Show();
                this.Hide();
            }
                panel1.Visible = true;
                iqresult.Visible = false;
        }
        
