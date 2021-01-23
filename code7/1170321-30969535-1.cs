    fieldValue = row.Cells[0].Text;
    DateTime timeNow = DateTime.Now;
    string constring = System.Configuration.ConfigurationManager.ConnectionStrings["ITCConnectionString"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(constring)) {
    // timeNow = Convert.ToDateTime(timeNow);  (not needed)
    using (SqlCommand cmd = new SqlCommand("UPDATE AktywneZgloszenia SET Data_przyjecia_do_realizacji= @pTimeNow  WHERE Nr_zgloszenia = @pFieldValue;", connection)) {
        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
            connection.Open();
	    cmd.Parameters.AddWithValue("@pTimeNow", timeNow); // <-- 'pass' timenow
	    cmd.Parameters.AddWithValue("@pFieldValue", fieldValue); // <-- 'pass' fieldValue
            cmd.ExecuteNonQuery(); // <--executeNon
            connection.Close();
            GridView1.DataBind();
        }
    }
}
