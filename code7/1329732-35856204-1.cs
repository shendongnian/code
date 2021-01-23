    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var l = GetList<Career>();
            }
    
            public static List<T> GetList<T>() where T : BaseClass
            {
                return new List<T>();
            }
    
            public static List<T> SelectCareer<T>(string cs, string query) where T : BaseClass, new()
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
    
                    var SQL = query;
                    var cmd = new SqlCommand(SQL, con);
    
                    var lista = new List<Career>();
                    con.Open();
                    try
                    {
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            var obj = new T();
                            obj.Load(dr);
                            lista.Add(obj);
                        }
                        dr.Close();
                    }
                    finally
                    {
                        con.Close();
                    }
                    return lista;
                }
            }
        }
    
        public class BaseClass
        {
            public string Name { get; set; }
    
            public virtual void Load(IDataReader dr)
            {
                
            }
        }
    
        public class Career : BaseClass
        {
            public override void Load(IDataReader dr)
            {
                CareerId = Convert.ToInt32(dr[0]);
                CareerName = (string)dr[1].ToString();
                CareerIsAct = (string)dr[2].ToString();
                CareerNote = (string)dr[3].ToString();
            }
    
            public string CareerNote { get; set; }
    
            public string CareerIsAct { get; set; }
    
            public string CareerName { get; set; }
    
            public int CareerId { get; set; }
        }
    
        public class Artist : BaseClass {}
    }
