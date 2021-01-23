    public class Model {
            public String Id {get;set;}
            public String Colour { get; set; }
    
            public Model(String id, String colour)
            {
                this.Id = id;
                this.Colour = colour;
            }
        }
    
        public interface IRepository
        {
            void Add(Model item);
            Model Get(string id);
        }
    
        public class RepositorySql : IRepository
        {
            private string constr;
            public RepositorySql(string connstr)
            {
                this.constr = connstr;
    
            }
            public void Add(Model item)
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("insert into table (userid,colour) values (@userid,@colour)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", item.Id);
                        cmd.Parameters.AddWithValue("@colour", item.Colour);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
    
    
            public Model Get(string id)
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from table where id=@id)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", item.UserId);
                        SqlDataReader dr  =cmd.ExecuteReader();
    
                        if (dr.Read())
                        {
                            Model i = new Model(dr["id"].ToString(), dr["colour"].ToString());
                            return i;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
