    public void dvÜrün_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "ürünEkle")
            {
                string adet = ((TextBox)dvÜrün.FindControl("Adet")).Text;
            }
        }
