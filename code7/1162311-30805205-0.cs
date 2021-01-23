    private void btnSentSMS_Click(object sender, EventArgs e)
    {
        var msg = txtMessage.Text;
        var phoneNumber = txtNumber.Text;
        var pdu = new SmsSubmitPdu(msg, phoneNumber, string.Empty);
        if(comm.SendMessage(pdu))
        {
            MessageBox.Show("sms sent");
            //STORE SEND SMS TO DATABASE
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = @"INSERT INTO SENTMESSAGE (ID, DATE, TIME, PHONENUMBER, MESSAGE) VALUES 
                       (SQ_SENTMESSAGE.NEXTVAL, '" + DateTime.Now + "', TO_DATE('" + DateTime.Now + "', 'dd/MM/yyyy hh24:mi:ss'), '"
                        + phoneNumber + "', '" + msg + "')";
    cmd.Connection = koneksi_manual.con;
    koneksi_manual.con.Open();// <= Open connection before executing the command.
    cmd.ExecuteNonQuery();
    koneksi_manual.con.Close(); //closing connection
    }
    else
    {
    MessageBox.Show("sms not sent");
    OracleCommand cmd = new OracleCommand();
    cmd.CommandText = @"INSERT INTO FAILEDMESSAGE (ID, DATE, TIME, PHONENUMBER, MESSAGE) VALUES 
                       (SQ_SENTMESSAGE.NEXTVAL, '" + DateTime.Now + "', TO_DATE('" + DateTime.Now + "', 'dd/MM/yyyy hh24:mi:ss'), '"
                        + phoneNumber + "', '" + msg + "')";
                cmd.Connection = koneksi_manual.con;
            koneksi_manual.con.Open();// <= Open connection before executing the command.
    cmd.ExecuteNonQuery();
    koneksi_manual.con.Close(); //closing connection
    }
    }
