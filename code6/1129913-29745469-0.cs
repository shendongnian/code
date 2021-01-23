    public interface IRepository
    {
        void AddRetail(Model item);
    }
    
    public class RepositorySql : IRepository
    {
        private string constr;
        public RepositorySql(string connstr)
        {
            this.constr = connstr;
    
        }
        public void AddRetail(Model item)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("insert into retail (userid,colour) values (@userid,@colour)", conn))
                {
                    cmd.Parameters.AddWithValue("@userid", item.UserId);
                    cmd.Parameters.AddWithValue("@colour", item.Colour);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
