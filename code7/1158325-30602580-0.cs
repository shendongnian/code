            private void btnConnect_Click(object sender, EventArgs e)
            {
                if (textBoxIP.Text !="" &&  textBoxName.Text !="" && textBoxPort.Text !="")
                {
                    client = new Client();
                    client.ClientName = textBoxName.Text;
                    client.ServerIp = textBoxIP.Text;
                    client.ServerPort = textBoxPort.Text;
                }
                else
                {
                  System.Windows.Forms.MessageBox.Show("You must fill all the boxes");
                }
            }
