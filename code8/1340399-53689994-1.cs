        public MySqlConnection con = WebApiConfig.conn();
        public IHttpActionResult GetAllProduct()
        {
            IList<product> pro = null;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from product", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                pro = ds.Tables[0].AsEnumerable().Select(dataRow => new product { Pname = dataRow.Field<string>("pname"), Pid = dataRow.Field<int>("pid"), Pprice = dataRow.Field<decimal>("pprice") }).ToList();
            }
            finally
            {
                con.Close();
            }
            if (pro.Count == 0)
            {
                return NotFound();
            }
            return Ok(pro);
        }
        public IHttpActionResult PostNewProduct(product pro)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT MAX(pid) from product";
                cmd.CommandType = CommandType.Text;
                int maxid = Convert.ToInt16(cmd.ExecuteScalar().ToString())+1;
                cmd.CommandText = "insert into product values(" + maxid + ",'" + pro.Pname + "'," + pro.Pprice + ")";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            return Ok();
        }
        public IHttpActionResult PutOldProduct(product pro)
        {
            string sql = "update product set pname='" + pro.Pname + "',pprice=" + pro.Pprice + " where pid=" + pro.Pid + "";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            string sql = "delete from product where pid=" + id + "";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            return Ok();
        }
