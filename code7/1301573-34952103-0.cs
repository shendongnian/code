    static class Northwind
    {
        public static Queue<Shipper> Queue { get; set; }
        public static List<Shipper> GetList()
        {
            var con = new SqlConnection("Data Source=DESKTOP-G5VBFCN;Initial Catalog=Northwind;Integrated Security=True");
            var cmd = new SqlCommand("SELECT CompanyName, Phone FROM Shippers",con);
            con.Open();
            var reader = cmd.ExecuteReader();
            var ShipList = new List<Shipper>();
            while (reader.Read())
            {
                var s = new Shipper
                {
                    CompanyName = reader["CompanyName"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
                ShipList.Add(s);
            }
            con.Close();
            return ShipList;
        }
        public static Queue<Shipper> GetQueue(List<Shipper> List)
        {
            Queue<Shipper> ShipperQueue = new Queue<Shipper>(List);
            return ShipperQueue;
        }
    }
