     using (SqlConnection con = new SqlConnection(_dbContext.Database.Connection.ConnectionString))
            {
                #region Connection Open
                SqlCommand cmd = new SqlCommand("mbl_GetCourseMat", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Par1", "par1");
                cmd.Parameters.AddWithValue("@Par2", 2);
                con.Open();
                #endregion
                #region Reader XML
                using (XmlReader reader = cmd.ExecuteXmlReader())
                {
                    while (reader.Read())
                    {
                        string result = reader.ReadOuterXml();
                        if (!String.IsNullOrEmpty(result))
                        {
                            XmlSerializer xs = new XmlSerializer(typeof(MobilCourseMatModel));
                            using (MemoryStream ms = new MemoryStream())
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes(result);
                                ms.Write(buffer, 0, buffer.Length);
                                ms.Position = 0;
                                using (XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8))
                                {
                                    model = (MobilCourseMatModel)xs.Deserialize(ms);
                                }
                            }
                        }
                    }
                }
                #endregion
                con.Close();
            }
