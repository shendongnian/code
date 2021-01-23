             Connect();
            if (serialPort1.IsOpen)
            {
                int MyInt = ToInt32(lblFirstNumber.Text);
                byte[] b = GetBytes(MyInt);
                serialPort1.Write(b, 0, 1);
                int MyInt2 = ToInt32(txtFirstNumber.Text);
                byte[] z = GetBytes(MyInt2);
                serialPort1.Write(z, 0, 1);
                int MyInt3 = ToInt32(txtSecondNumber.Text);
                byte[] p = GetBytes(MyInt3);
                serialPort1.Write(p, 0, 1);
                serialPort1.Close();
            }
            else
            {
                MessageBox.Show("Please control your connection");
            }
