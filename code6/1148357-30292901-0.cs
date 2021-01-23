     protected void Page_Load(object sender, EventArgs e)
    {
        ServiceReference2.WebServiceClient o = new ServiceReference2.WebServiceClient();
        Artist [] artists = o.GetAllArtists().ToArray(); //Exception will not //come now
        string str = "";
        foreach (Artist artist in artists){
            str += artist.ArtistID + " ";
        }
        Response.Write(str);
        gv.DataSource = artists;
        gv.DataBind();
    }
