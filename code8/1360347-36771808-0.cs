    protected void Page_Load(object sender, EventArgs e)
    {
         if(!IsPostBack)
         {
            string ID = Request.QueryString["Id"].ToString();
            SqlConnection baglan = new SqlConnection(ConnectionString3);
            baglan.Open();
            SqlCommand com = new SqlCommand("Select * from pkategori where Id='" + ID + "'", baglan);
        
            SqlDataReader oku = com.ExecuteReader();
            if (oku.Read())
            {
                baslik.Text = oku["Tanim"].ToString();
                detaylar.Text = oku["Detaylar"].ToString();
            }
            else
            {
                baslik.Text = "Bulunmadı";
            }
        }
    }
