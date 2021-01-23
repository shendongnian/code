           btnReg.Text = "REGISTER";
           btnReg.Name = "btnReg";
           if (editClients.HasRows)
            {
                if (editClients.Read())
                {
                    MessageBox.Show("Client Successfully Updated!");
                }
            } 
            btnReg.Click -= this.btnUpdt_Click;
            btnReg.Click += this.btnReg_Click;
              
