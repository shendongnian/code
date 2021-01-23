        private void SqlExportApplicantInfo(List<Applicant_info> applicants)
        {
            const string storedProcedureName = @"UploadApplicants";  // Your sql stored procedure name here
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.ApplicationName = "AppName";      // Set your application name here
            connectionBuilder.ConnectTimeout = 30;
            connectionBuilder.DataSource = "(local)";           // Set your server name here
            connectionBuilder.InitialCatalog = "SimplyData";    // Set your database here
            connectionBuilder.IntegratedSecurity = true;
            string connectionString = connectionBuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        MemoryStream memoryStream = new MemoryStream();
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Applicant_info>));
                        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                        serializer.Serialize(xmlTextWriter, applicants);
                        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                        memoryStream.Position = 0;
                        SqlXml applicantsXml = new SqlXml(memoryStream);
                        SqlParameter parameter = command.Parameters.AddWithValue("@applicantsXml", applicantsXml);
                        parameter.SqlDbType = SqlDbType.Xml;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception exception)
                {
                    throw new ApplicationException("Failed to upload applicant list to sql.", exception);
                }
            }
        }
