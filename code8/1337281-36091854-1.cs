      int? BedId = null;
      int m_BedID = 0;
      if(Int32.TryParse(tbPatientBedID.Text.Trim(), out m_BedID))
      {
         BedId = m_BedID;
      }      
            
      cmd.Parameters.Add("@inOrOut", OleDbType.VarWChar).Value = tbPatientStatus.Text;
      cmd.Parameters.Add("@BedID", OleDbType.Integer).Value = BedID;
