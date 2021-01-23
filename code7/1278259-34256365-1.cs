    using (SqlConnection conn = new SqlConnection(conStr))
    {
        var accountName = comBoxSlctAcnt.Text;
        var balance = textBoxBal.Text;
        var balanceType = comBoxBalType.Text;
                
        if (balanceType == "Cr" || balanceType == "Dr")
        {
            insrtcmd = new SqlCommand();
            insrtcmd.CommandText = string.Format(
                                         @"UPDATE Accoutns SET {0} = @bal Where AccntName = @acntName", 
                                         balanceType == "Cr" ? "AccntCrVal" : "AccntDrVal");
            insrtcmd.Connection = conn;
            insrtcmd.Parameters.AddWithValue("@acntName", accountName);
            insrtcmd.Parameters.AddWithValue("@bal", balance);
            conn.Open();
            insrtcmd.ExecuteNonQuery();
        }
        else
        {
            MessageBox.Show("Please Enter Values and Select the Balance Type [ Dr | Cr ] ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
