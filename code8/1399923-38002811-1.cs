    // You might want to consider making your SQL type a DateTime of 
    // some sort to prevent invalid DateTime VARCHAR's from being 
    // stored in your leaving_time and arrival_time columns.
    var leavingTime = dateTimePicker1.Value.ToString();
    // Presumably you've already done validation to make sure
    // textBox1.Text contains a valid Int32 value.
    var milNo = int.Parse(textBox1.Text);
    
    // You can put the SQL out here on a multi-line string literal
    // to make it more readable.  Also notice how it uses parameters
    // instead of string concatenation.
    var sql = @"
    UPDATE Hodor_data 
    SET leaving_time = @LeavingTime
    WHERE 
        mil_no = @MilNo AND 
        times = 
        (
            SELECT MAX(times) 
            FROM Hodor_data
        )
    ";
    
    conn.Open();
    SqlCommand sq = new SqlCommand(sql, conn);
    sq.Parameters.AddWithValue("@LeavingTime", leavingTime);
    sq.Parameters.AddWithValue("@MilNo", milNo);
    sq.ExecuteNonQuery();
    conn.Close();
