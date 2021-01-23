    public RootObject GetRecipes()
    {
        string summonerID = Session["summonerID"].ToString();
        string downloadedString;
        WebClient client = new WebClient();
        downloadedString = client.DownloadString("https://tr.api.pvp.net/api/lol/tr/v1.3/game/by-summoner/" + summonerID + "/recent?api_key=55686aef-da52-4184-b987-98799662d92e"); //tırnak içerisine istediğiniz web adresini yazınız
        RootObject liste = JsonConvert.DeserializeObject<RootObject>(@downloadedString);
        return liste;
        lblYazi.Text = liste.ToString();  // never reaches this code
    }
