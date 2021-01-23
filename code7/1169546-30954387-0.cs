    private void button1_Click(object sender, EventArgs e)
       {
          string your_string = dateTimePicker1.Value.ToString();
          try
          {
              this.examinesTableAdapter.FillBy(this.dbSpinDataSet.examines, your_string, textBox2.Text, textBox3.Text);
          }
          catch (SystemException ex)
          {
            System.Windows.Forms.MessageBox.Show(ex.Message);
          }
        }
