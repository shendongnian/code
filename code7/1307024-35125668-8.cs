    using(SqlConnection cn = new SqlConnection(con))
    using(SqlCommand cmdUpdate = new SqlCommand("UPDATE OINV SET U_IDU_HFP = @HFP, U_IDU_FAKTURPAJAK = @FP, U_IDU_FPDATE = @FPDATE WHERE DocEntry = @DocEntry;", cn))
    {
        cn.Open();
        using(SqlTransaction tr = cn.BeginTrasaction())
        {
            cmdUpdate.Transaction = tr;
            cmdUpdate.Parameters.Add("@HFP", SqlDbType.NVarChar);
            cmdUpdate.Parameters.Add("@FP", SqlDbType.NVarChar);
            cmdUpdate.Parameters.Add("@FPDATE", SqlDbType.NVarChar);
            cmdUpdate.Parameters.Add("@DocEntry", SqlDbType.NVarChar);
            foreach (DataGridViewRow item in dgvInputPKP.Rows)
            {
                cmdUpdate.Parameters["@HFP"].Value = item.Cells[10].Value;
                cmdUpdate.Parameters["@FP"].Value = item.Cells[11].Value;
                cmdUpdate.Parameters["@FPDATE"].Value = item.Cells[9].Value;
                cmdUpdate.Parameters["@DocEntry"].Value = item.Cells[1].Value;
                cmdUpdate.ExecuteNonQuery();
           }
           tr.Commit();
       }
    }
    MessageBox.Show("Record Updated Successfully");
