    protected void btnGiris_Click(object sender, EventArgs e)
    {
           string sorgu = "Select * from Personnels where VS_personnel_username = @kullaniciAdi AND VS_personnel_password= @sifre ";
           SqlCommand cmd = new SqlCommand(sorgu, cnn);
           cmd.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
           cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
           cnn.Open();
           SqlDataReader dr = cmd.ExecuteReader();
           if (dr.Read())
           {
               Session.Timeout = 300;
               Session.Add("kullaniciAdi", dr["VS_personnel_username"].ToString());
               Session.Add("your_user_id_parameter", dr["personnel_type_id"].ToString());
               Response.Redirect(Request.RawUrl);
           }
           else
           {
               lblSonuc.Text = "Kullanıcı girişi sağlanamadı";
           }
           cnn.Close();
    }
