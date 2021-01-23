    public class Adres
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Address { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult JsonExample()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveToDatabase(Adres adres)
        {
            adres.Date = DateTime.Now;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand("InsertAdres",connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date",adres.Date);
                    command.Parameters.AddWithValue("@Latitude",adres.Latitude);
                    command.Parameters.AddWithValue("@Longitude",adres.Longitude);
                    command.Parameters.AddWithValue("@Address",adres.Address);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return View();
        }
    }
