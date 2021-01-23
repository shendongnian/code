    using (OleDbConnection DBConnect = new OleDbConnection())
    {
          DBConnect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\bkoso\documents\visual studio 2015\Projects\ParkingDatabase\ParkingDatabase\ParkingData.accdb";
         using(OleDbCommand com = new OleDbCommand("INSERT INTO [Guest Info]([Guest First Name], [Guest Last Name], [Room Number], [Departure Date], [Return Date], [Vehicle Colour], [Vehicle Make], [Plate Number], [Contact First Name], [Contact Last Name], [Contact Number], [Contact Email], [Tag Number]) Values(@[Guest First Name], @[Guest Last Name], @[Room Number], @[Departure Date], @[Return Date], @[Vehicle Colour], @[Vehicle Make], @[Plate Number], @[Contact First Name], @[Contact Last Name], @[Contact Email], @[Contact Email], @[Tag Number])", DBConnect))
         {
           com.Parameters.AddWithValue("@[Guest First Name]", txtBxGstFName.Text);
           com.Parameters.AddWithValue("@[Guest Last Name]", txtBxGstLName.Text);
           // .. snip other params .. //
           DBConnect.Open();
           com.ExecuteNonQuery();
           DBConnect.Close();
         }
    }
