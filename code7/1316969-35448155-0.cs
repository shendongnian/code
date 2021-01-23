     Private Void BtnSend_Click(Object Sender,EventArg e)
        {
          Thread th = new Thread(new ThreadStart(SendMSM));
        }
        
   
     Private void SendMSM()
        {
        if (CommSetting.comm.IsConnected() == true)
        {
            int i;
            for (i = 0; i < gridView1.DataRowCount; i++)
            {
                string pesan = gridView1.GetRowCellValue(i,"MESSAGE").ToString();
                string ttd = lblTandaTangan.Text;
                string msg = pesan + Environment.NewLine + Environment.NewLine + ttd;  //SENT MESSAGE USING SIGNATURE
        
            var listPhoneNumber = new List<string>();
            listPhoneNumber.Add(gridView1.GetRowCellValue(i, "PHONENUMBER").ToString());
        
            foreach (var phoneNumber in listPhoneNumber)
            {
                var pdu = new SmsSubmitPdu(msg, phoneNumber, string.Empty);
                CommSetting.comm.SendMessage(pdu);
        
                //---------------STORE TO ORACLE DB--------------------
                if (koneksi_manual.con.State == ConnectionState.Open)
                {
                    koneksi_manual.con.Close();
                }
                koneksi_manual.con.Open();
        
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = @"INSERT INTO MESSAGESENT (ID, DATE, TIME, PHONENUMBER, MESSAGE) VALUES 
                                (SQ_MESSAGESENT.NEXTVAL, '" + DateTime.Now + "', TO_DATE('" + DateTime.Now + "', 'dd/MM/yyyy hh24:mi:ss'), '"
                                    + gridView1.GetRowCellValue(i, "PHONENUMBER") + "', '" + pesan.Replace("'", "''") + "', '" + Program.IDUser + "')";// <= Use gridView1.GetRowCellValue to get the cell value.
                cmd.Connection = koneksi_manual.con;
                cmd.ExecuteNonQuery();
        
                //Sleeps system for 1000ms for refreshing GSM Modem
                System.Threading.Thread.Sleep(1000);
        
                //DELETE MESSAGE SENT FROM OUTBOX
                var obj = gridView1.GetRowCellValue(i, "ID");
        
                OracleCommand cmd2 = new OracleCommand();
                cmd2.CommandText = "DELETE FROM OUTBOX WHERE ID = '" + obj + "'";
                cmd2.Connection = koneksi_manual.con;
                cmd2.ExecuteNonQuery();
            }
            MessageBox.Show("Message Sent", "Notif");
          }
        }
