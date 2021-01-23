    string sqlStatement = @"SELECT Orders.[ID], Orders.[Checkintime], 
                            Orders.[RoomPrice], Orders.[OrderNo], 
                            Particulars.FirstName, Particulars.LastName 
                            FROM Orders INNER JOIN Particulars 
                            ON Orders.[ID] = Particulars.[OrderID]
                            where Checkintime between @init AND @end";
    using(SqlConnection cnn = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand(sqlStatement, cnn))
    {
         cnn.Open();
         cmd.Parameters.Add("@init", SqlDbType.DateTime).Value = dateOnly;
         cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = endDateOnly;
         .... remainder of your code that reads back your data.....
    }
