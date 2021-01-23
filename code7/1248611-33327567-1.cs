    protected void btnSong6_Click(object sender, EventArgs e)
        {
            string Name = "In the end";
            Product Music = new Product();
            string constr = ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string SelectCommand = "select Genre,Name,Artist, Price from Music WHERE name = '" + Name + "' ";
            SqlCommand cmd = new SqlCommand(SelectCommand, con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            Music.Artist = read["artist"].ToString();
            Music.Name = read["name"].ToString();
            Music.Genre = read["genre"].ToString();
            Music.Price = Convert.ToDecimal(read["price"]);
            //ADD PRICE!!
            listMusic.Items.Add(Music.Genre + " : " + Music.Artist + " - " + Music.Name + " " + Music.Price);
        }
