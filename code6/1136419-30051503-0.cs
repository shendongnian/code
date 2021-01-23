    public ActionResult Index()
        {
            string str = @"Data Source=DEV_3\SQLEXPRESS;Initial Catalog=DB_Naved_Test;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "select * from tbl_country ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<SelectListItem> li = new List<SelectListItem>();
            while (rdr.Read())
            {
                li.Add(new SelectListItem { Text = rdr[1].ToString(), Value = rdr[0].ToString() });
            }
            ViewData["country"] = li;
            return View();
        }
        public JsonResult StateList(int Id)
        {
            string str = @"Data Source=DEV_3\SQLEXPRESS;Initial Catalog=DB_Naved_Test;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "select * from tbl_states where cid='" + Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<SelectListItem> li = new List<SelectListItem>();
            while (rdr.Read())
            {
                li.Add(new SelectListItem { Text = rdr[1].ToString(), Value = rdr[0].ToString() });
            }
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Citylist(int id)
        {
            string str = @"Data Source=DEV_3\SQLEXPRESS;Initial Catalog=DB_Naved_Test;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "select * from tbl_cities where stateid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<SelectListItem> li = new List<SelectListItem>();
            while (rdr.Read())
            {
                li.Add(new SelectListItem { Text = rdr[1].ToString(), Value = rdr[0].ToString() });
            }
            return Json(li, JsonRequestBehavior.AllowGet);
        }
