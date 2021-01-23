    DateTime chequeDate;
                        var value = (object)DBNull.Value;
                        if (DateTime.TryParseExact(txtmaskchequedate.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out chequeDate))
                        {
                            value = chequeDate;
                        }
    
    
                        cmd.Parameters.AddWithValue("@Cheque_Date", value);
