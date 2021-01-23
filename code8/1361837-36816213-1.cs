    public static void featuresentry()
    {
        string connectionString = HandVeinPattern.Properties.Settings.Default.HandVeinPatternConnectionString;
        string insertQuery = "INSERT INTO FEATURES(UserID, Angle, ClassID, Octave, PointX, PointY, Response, Size) VALUES(@UserID, @Angle, @ClassID, @Octave, @PointX, @PointY, @Response, @Size)";
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        {
            // define your parameters ONCE outside the loop, and use EXPLICIT typing
            command.Parameters.Add("@UserID", SqlDbType.Int);
            command.Parameters.Add("@Angle", SqlDbType.Double);
            command.Parameters.Add("@ClassID", SqlDbType.Double);
            command.Parameters.Add("@Octave", SqlDbType.Double);
            command.Parameters.Add("@PointX", SqlDbType.Double);
            command.Parameters.Add("@PointY", SqlDbType.Double);
            command.Parameters.Add("@Response", SqlDbType.Double);
            command.Parameters.Add("@Size", SqlDbType.Double);
    
            connection.Open();
    
            for (int i = 0; i < Details.modelKeyPoints.Size; i++)
            {
                // now just SET the values
                command.Parameters["@UserID"].Value = Details.ID;
                command.Parameters["@Angle"].Value = Convert.ToDouble(Details.modelKeyPoints[i].Angle);
                command.Parameters["@ClassID"].Value = Convert.ToDouble(Details.modelKeyPoints[i].ClassId);
                command.Parameters["@Octave"].Value = Convert.ToDouble(Details.modelKeyPoints[i].Octave);
                command.Parameters["@PointX"].Value = Convert.ToDouble(Details.modelKeyPoints[i].Point.X);
                command.Parameters["@PointY"].Value = Convert.ToDouble(Details.modelKeyPoints[i].Point.Y);
                command.Parameters["@Response"].Value = Convert.ToDouble(Details.modelKeyPoints[i].Response);
                command.Parameters["@Size"].Value = Convert.ToDouble(Details.modelKeyPoints[i].Size);
    
                command.ExecuteNonQuery();
            }
        }
    }
