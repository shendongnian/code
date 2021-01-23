    private void displaydata_event2(object sender, EventArgs e)
    {
        Task.Delay(10000).ContinueWith(x => 
        {
            txt_data.AppendText(in_data + "\n");
            string inStr;
            inStr = in_data;
            //MessageBox.Show(inStr.Length.ToString());
            if (inStr.Length == 12)
            {
                int indexOfSpace = inStr.IndexOf(' ');
                string Patient = inStr.Substring(indexOfSpace + 1);
                int rx = 0;
                int selected = 0;
                txtData1.Text = Patient;
                rx = Convert.ToInt16(Patient);
                selected = Convert.ToInt16(txt_pnorec.Text);
                if (rx != selected)
                {
                    MessageBox.Show("Please check patient settings");
                }
            }
            else if (inStr.Length == 24)
            {
                label2.Text = "Patient is not selected!";
                label2.BackColor = Color.Red;
            }
            else if (inStr.Length == 10)
            {
                int indexOfSpace = inStr.IndexOf(':');
                string Temp = inStr.Substring(indexOfSpace + 1);
                txtData2.Text = Temp;
                double tempflo;
                tempflo = Convert.ToDouble(Temp);
                if (tempflo > 20)
                {
                    lbl_temp.Text = "Fever";
                    lbl_temp.BackColor = Color.Red;
                }
            }
            else if (inStr.Length == 9)
            {
                int indexOfSpace = inStr.IndexOf(':');
                string ECG = inStr.Substring(indexOfSpace + 1);
                txtData3.Text = ECG;
            }
            else if (inStr.Length == 19 || inStr.Length == 20)
            {
                int indexOfSpace = inStr.IndexOf(':');
                string Systolic = inStr.Substring(indexOfSpace + 1);
                txtData4.Text = Systolic;
            }
            else if (inStr.Length == 21 || inStr.Length == 22)
            {
                int indexOfSpace = inStr.IndexOf(':');
                string Diastolic = inStr.Substring(indexOfSpace + 1);
    
                txtData5.Text = Diastolic;
            }
            else if (inStr.Length == 16)
            {
                int indexOfSpace = inStr.IndexOf(':');
                string Pulse = inStr.Substring(indexOfSpace + 1);
                txtData6.Text = Pulse;
            }
            else if (inStr.Length == 23 || inStr.Length == 17 || inStr.Length == 27 || inStr.Length == 30 || inStr.Length == 35 || inStr.Length == 29)
            {
                lbl_bp.Text = inStr;//to display status of BP (Normal,prehypotension etc)
                string bp;
                bp = inStr;
                if (bp.Length == 23 || bp.Length == 27 || bp.Length == 31 || bp.Length == 35 || bp.Length == 30)
                {
                    lbl_bp.BackColor = Color.Red;
                }
                else if (bp.Length == 17)
                {
                    lbl_bp.BackColor = Color.LightGray;
                }
            }
            else if (inStr.Length == 32 || inStr.Length == 25 || inStr.Length == 34 || inStr.Length == 33 || inStr.Length == 26 || inStr.Length == 31)
            {
                int indexOfSpace = inStr.IndexOf(':');
                string Acc = inStr.Substring(indexOfSpace + 1);
                txtData7.Text = Acc;
                string test = inStr;
                if (test.Length == 25 || test.Length == 34 || test.Length == 33 || test.Length == 26)
                {
                    label21.Text = "Check on patient!";
                    label21.BackColor = Color.Red;
                }
                else if (test.Length == 32)
                {
                    label21.Text = "";
                    label21.BackColor = Color.LightGray;
                }
            }
            else
            {
            }
             if (txtData1.Text != "" && txtData2.Text != "" && txtData3.Text != "" && txtData4.Text != "" && txtData5.Text != "" && txtData6.Text != "" && txtData7.Text != "")
            {
                try
                {
                    connection2.Open();
                    OleDbCommand command2 = new OleDbCommand();
                    command2.Connection = connection2;
                    command2.CommandText = "insert into MedicalRecord (PatientNumber,FirstName,LastName,IC,Temperature,ECG,Systolic,Diastolic,Pulse) values('" + txt_pnorec.Text + "','" + txt_fnamerec.Text + "','" + txt_lnamerec.Text + "','" + txt_icrec.Text + "','" + txtData2.Text + "','" + txtData3.Text + "','" + txtData4.Text + "','" + txtData5.Text + "','" + txtData6.Text + "')";
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Info Stored");
                    connection2.Close();
                    txtData1.Text = "";
                    txtData2.Text = "";
                    txtData3.Text = "";
                    txtData4.Text = "";
                    txtData5.Text = "";
                    txtData6.Text = "";
                    txtData7.Text = "";
                    Thread.Sleep(interval);
                    MessageBox.Show("Start");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
                txtData1.Text = "";
                txtData2.Text = "";
                txtData3.Text = "";
                txtData4.Text = "";
                txtData5.Text = "";
                txtData6.Text = "";
                txtData7.Text = "";  
            }
        });
    }
