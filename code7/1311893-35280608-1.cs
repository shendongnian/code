    public List<RootObject> GetRecipes()
    {
        string summonerID = Session["summonerID"].ToString();
        string downloadedString;
        WebClient client = new WebClient();
        downloadedString = client.DownloadString("https://tr.api.pvp.net/api/lol/tr/v1.3/game/by-summoner/" + summonerID + "/recent?api_key=55686aef-da52-4184-b987-98799662d92e"); //tırnak içerisine istediğiniz web adresini yazınız
        List<RootObject> liste = new List<RootObject>();  // create the return list
        RootObject e = JsonConvert.DeserializeObject<RootObject>(@downloadedString);
        liste.Add(e);  // add the reserialized object to the list we are returning
        return liste;
        lblYazi.Text = liste.ToString();  // never reaches this code
    }
