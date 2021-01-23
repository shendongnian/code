    // Here is the value of the string which IS NOT actually a verbatim string literal, but a value passed on from a selected dropdown list.
    strEmailText = "We're writing in regard to XXX mentioned above.\r\nPlease contact us.\r\nWe're available by direct reply.\r\nThank you for your assistance."
    // Here I create the actual SQL string for use to query the database
    strSQL = @"SELECT DISTINCT TBL_EmailText.ID FROM TBL_EmailText WHERE TBL_EmailText.Text = @EmailText";
    using (var sqlCmd = new SqlCommand(strSQL, conn))
    {
        sqlCmd.CommandType = CommandType.Text;
        sqlCmd.Parameters.Add(new SqlParameter { ParameterName = "@EmailText", SqlDbType = SqlDbType.NVarChar, Value = strEmailText });
        using(SqlDataReader rdr = sqlCmd.ExecuteReader())
        {
            //Do something with the data
        }
    }
