        private void cmdSubmit_Click(object sender, EventArgs e)
        {
          var name = txtName.Text;
          var age = Convert.ToByte(txtAge.Text);
          MessageBox.Show($"Your name is {name} and You're {age} years old.");
        }
           
