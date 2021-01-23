      public static void databaseFileRead(string varID, string varPathToNewLocation) {
         MemoryStream memoryStream = new MemoryStream();
    using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
    using (var sqlQuery = new SqlCommand(@"SELECT [Logo] FROM [dbo].[Firma] WHERE [RaportID] = @varID", varConnection)) {
        sqlQuery.Parameters.AddWithValue("@varID", varID);
        using (var sqlQueryResult = sqlQuery.ExecuteReader())
            if (sqlQueryResult != null) {
                sqlQueryResult.Read();
                var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                //using (var fs = new MemoryStream(memoryStream, FileMode.Create, FileAccess.Write)) {
                memoryStream.Write(blob, 0, blob.Length);
                //}
            }
    }
      
       pictureBox1.Image = Image.FromStream(memoryStream);
}
