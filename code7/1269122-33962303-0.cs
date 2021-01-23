    public static void InsertImage(int inventoryID, int businessID, FileInfo file, string sqlConnection)
    {
        var list = new List<byte>();
        using (var stream = file.Open(FileMode.Open))
        {
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            list.AddRange(data);
        }
        var bmp = System.Drawing.Image.FromFile(file.FullName, true);
        using (var conn = new SqlConnection(sqlConnection))
        {
            conn.Open();
            var imageId = -1;
            var sqlSelect = "SELECT [ImageId] FROM [dbo].[ImageTable] WHERE [InventoryId]=@InventoryId;";
            using (var cmd = new SqlCommand(sqlSelect, conn))
            {
                cmd.Parameters.Add("@InventoryId", System.Data.SqlDbType.Int).Value = inventoryID;
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        var o = r["ImageId"];
                        if ((o != null) && (o != DBNull.Value))
                        {
                            imageId = (int)o;
                        }
                    }
                }
            }
            if (imageId == -1)
            {
                var sqlCmd = "INSERT INTO [dbo].[ImageTable] " +
                    "([InventoryId], [ImageFileName], [ImageSize], [ImageWidth], [ImageHeight], [ImageBytes]) " +
                    "VALUES " +
                    "(@InventoryId,  @ImageFileName,  @ImageSize,  @ImageWidth,  @ImageHeight,  @ImageBytes); ";
                using (var cmd = new SqlCommand(sqlCmd, conn))
                {
                    cmd.Parameters.Add("@InventoryId", System.Data.SqlDbType.Int).Value = inventoryID;
                    cmd.Parameters.Add("@ImageFileName", System.Data.SqlDbType.VarChar, 255).Value = file.Name;
                    cmd.Parameters.Add("@ImageSize", System.Data.SqlDbType.Int).Value = list.Count;
                    cmd.Parameters.Add("@ImageWidth", System.Data.SqlDbType.SmallInt).Value = bmp.Width;
                    cmd.Parameters.Add("@ImageHeight", System.Data.SqlDbType.SmallInt).Value = bmp.Height;
                    cmd.Parameters.Add("@ImageBytes", System.Data.SqlDbType.VarBinary, -1).Value = list.ToArray();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
