    public HttpResponseMessage CheckDevice(string device)
    {
        try
        {
            devices = new List<DeviceClass>();
            using (connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("uspCheckDeviceID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@sp", SqlDbType.VarChar).Value = device;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                DeviceClass model = new DeviceClass();
                                model.DeviceId = reader.GetValue(0).ToString();
                                model.Name = reader.GetValue(1).ToString();
                                model.Owner = reader.GetValue(2).ToString();
                                devices.Add(model);
                            }
                        }
                        connection.Close();
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK,
                    devices.ToList());
        }
        catch (Exception e)
        {
            //Request.CreateErrorResponse is OK too
            var err = new HttpRequestMessage().
                        CreateErrorResponse(HttpStatusCode.InternalServerError,
                        e.ToString());
            return new HttpResponseException(err);
        }
    }
