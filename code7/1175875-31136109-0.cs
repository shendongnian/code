    public static bool ValidateSerNo(string ser)
        {
            if (!string.IsNullOrEmpty(ser))
            {
                if (ser.Trim().Length == 11)
                {
                    if (ser.Trim().ToUpper().Substring(0, 2) == "LP")
                    {
                        if (Microsoft.VisualBasic.Information.IsNumeric(ser.Substring(2, 9)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if ((BattVoltMmnt.ValidateSerNo(txtbox_Serialno.Text.Trim().ToUpper()) == false))
            { MessageBox.Show("Enter correct serial number"); 
              
            }
         }
