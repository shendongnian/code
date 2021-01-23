        private bool IsRead = false;
        string dwEnrollNumber;
        int dwVerifyMode, dwInOutMode, dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond,           dwWorkcode, dwMachineNumber;
        public zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
      
       public class ClsMachineBL
       {
        public String DownloadDataFromBiomatrix(ClsMachineML prp)
        {
            try
            {
                string constr = CommonConnection.ConStr;
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("Prc_InsertDatafromBiomatrix", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@dwMachineNumber", prp.dwMachineNumber);
                cmd.Parameters.AddWithValue("@dwEnrollNumber", prp.dwEnrollNumber);
                cmd.Parameters.AddWithValue("@dwVerifyMode", prp.dwVerifyMode);
                cmd.Parameters.AddWithValue("@dwInOutMode", prp.dwInOutMode);
                cmd.Parameters.AddWithValue("@dwYear", prp.dwYear);
                cmd.Parameters.AddWithValue("@dwMonth", prp.dwMonth);
                cmd.Parameters.AddWithValue("@dwDay", prp.dwDay);
                cmd.Parameters.AddWithValue("@dwHour", prp.dwHour);
                cmd.Parameters.AddWithValue("@dwMinute", prp.dwMinute);
                cmd.Parameters.AddWithValue("@dwSecond", prp.dwSecond);
                cmd.Parameters.AddWithValue("@dwWorkcode", prp.dwWorkcode);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
    
                BL.clsCommon objerr = new BL.clsCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return result;
        }
       }
    
    
    
    public class ClsMachineML
    {
        public string Id { get; set; }
        public string MachineNo { get; set; }
        public string MachineIP { get; set; }
        public string PortNo { get; set; }
        public string Remark { get; set; }
        public string Tuser { get; set; }
        public string Tdate { get; set; }
        public string Status { get; set; }
        public int  dwMachineNumber { get; set; }
        public string dwEnrollNumber { get; set; }
        public int dwVerifyMode { get; set; }
        public int dwInOutMode { get; set; }
        public int dwYear { get; set; }
        public int dwMonth { get; set; }
        public int dwDay { get; set; }
        public int dwHour { get; set; }
        public int dwMinute { get; set; }
        public int dwSecond { get; set; }
        public int dwWorkcode { get; set; }
        public string User_Id { get; set; }
        public string Name { get; set; }
        public int Finger_Index { get; set; }
        public string Finger_Image { get; set; }
        public int Privilege { get; set; }
        public string Passwords { get; set; }
        public bool Enabled { get; set; }
        public int Flag { get; set; }
        public string  Fromdate { get; set; }
        public string Todate { get; set; }
    }
    
    
    
        private void btndownload_Click(object sender, EventArgs e)
        {
             ClsMachineBL obj = new ClsMachineBL();
             ClsMachineML prp = new ClsMachineML();
    
            try
            {
                if (cbmachine.Text == "" || cbmachine.Text == "Select")
                {
                    MessageBox.Show("Please Select Machine");
                    cbmachine.Focus();
                    return;
                }
    
                progressBar1.Visible = true;
                  bool bIsConnected = axCZKEM1.Connect_Net(ip_address_of_your_machine, 4370);   // 4370 is port no of attendance machine
                if (bIsConnected == true)
                {
                    IsRead = axCZKEM1.ReadGeneralLogData(dwMachineNumber);
                    if (IsRead == true)
                    {
                        progressBar1.Maximum = 100;
                        progressBar1.Step = 1;
                        progressBar1.Value = 0;
                        while (axCZKEM1.SSR_GetGeneralLogData(dwMachineNumber, out dwEnrollNumber, out dwVerifyMode, out dwInOutMode, out dwYear, out                                dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkcode))
                        {
                            prp.dwDay = dwDay;
                            prp.dwEnrollNumber = dwEnrollNumber;
                            prp.dwHour = dwHour;
                            prp.dwInOutMode = dwInOutMode;
                            prp.dwMachineNumber = dwMachineNumber;
                            prp.dwMinute = dwMinute;
                            prp.dwMonth = dwMonth;
                            prp.dwSecond = dwSecond;
                            prp.dwVerifyMode = dwVerifyMode;
                            prp.dwWorkcode = dwWorkcode;
                            prp.dwYear = dwYear;
                            string add = obj.DownloadDataFromBiomatrix(prp);
                            progressBar1.PerformStep();
                        }
    
                        string export = obj.ExportToAttendance(prp);
                        MessageBox.Show("Attendance Downloaded Successfully");
                        progressBar1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No Log Found....");
                        progressBar1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Device Not Connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
