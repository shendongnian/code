        public List<Partner> GetParentsWithChildren()
        {
            List<Parent> parents = new List<Parent>();
            List<Child> children = new List<Child>();
          
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetPartnersWithDevices", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ParentId", 1);
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {                   
                    parents = GetModelFromReader<Parent>(reader);
                    reader.NextResult();                    
                    children = GetModelFromReader<Child>(reader);
                }
                foreach (Parent parent in parents)
                {
                    parent.Children = children.Where(x => x.ParentId == parent.Id).ToList();
                }
            }
            return partners;
        }
