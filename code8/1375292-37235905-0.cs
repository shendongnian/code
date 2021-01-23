    DateTime dt1 = Convert.ToDateTime(txtdari.Text);
    DateTime dt2 = Convert.ToDateTime(txtsampai.Text);
    ////////ARI DATE/////////
    OracleParameter fromDateParameter = new OracleParameter();
    fromDateParameter.OracleDbType = OracleDbType.Date;
    fromDateParameter.Value = dt1;
    ////////SAMPAI DATE/////////
    OracleParameter toDateParameter = new OracleParameter();
    toDateParameter.OracleDbType = OracleDbType.Date;
    toDateParameter.Value = dt2;
    this.oracleDataAdapter4.SelectCommand = new OracleCommand("SELECT c.SUB_DISTRIBUTOR , c.MID  , c.REKNO , b.ID, b.TERMINAL_ID , b.TANGGAL, b.KETERANGAN , b.DEBIT , b.KREDIT , b.SALDO , b.REFF_NO,b.PRODUK,b.NO_PELANGGAN,   b.SN_ID , b.STATUS from MERCHANT c JOIN DAILY b  ON (b.REKENING_NO = c.REKNO) where TANGGAL BETWEEN :fromDateParameter AND :fromDateParameter)”, conn);
    OracleDataAdapter da = new OracleDataAdapter(cmd);
    da.SelectCommand.Parameters.Add(fromDateParameter);           
    da.SelectCommand.Parameters.Add(toDateParameter);  
    DataTable dt = new DataTable();
    da.Fill(dt);
  
