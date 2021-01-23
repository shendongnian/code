    public IEnumerable<LightItemDTO> GetLightItem(string itemText, string sqlConnectionString)
            {
                var results = new List<LightItemDTO>();
    
                using (var con = new SqlConnection(sqlConnectionString))
                {
                    using (var cmd = new SqlCommand("sp_lightItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = itemText;
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            results.Add(new LightItemDTO
                            {
                                Id = Convert.ToInt32(reader["itemID"]),
                                Name = reader["itemName"].ToString(),
                                Location = reader["itemLocation"].ToString(),
                                ChangedBy = reader["itemChBy"].ToString()
                            });
                        }
                    }
                }
    
                return results;
            }
