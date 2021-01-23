	public class ImageService
	{
		public static void SaveImage(string fileName)
		{
			byte[] img;
            using(var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                img = new byte[fileStream.Length];
                fileStream.Read(img, 0, Convert.ToInt32(fileStream.Length));
            }
			using (var con = new SqlConnection(DBHandler.GetConnectionString()))
			using (var cmd = new SqlCommand("SaveImage", con))
			{
				con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@img", SqlDbType.Image).Value = img;
                cmd.ExecuteNonQuery();
			}
		}
		public static DataTable GetAllImageIDs
		{
			var dtt = new DataTable();
			using (var dc = new SqlDataAdapter("ReadAllImageIDs", DBHandler.GetConnectionString()))
			{
				dc.SelectCommand.CommandType = CommandType.StoredProcedure;
				dc.Fill(dtt);
			}
			return dtt;
		}
	}
