    protected void Page_Load(object sender, EventArgs e)
    {
    string[] filesPath = Directory.GetFiles(Server.MapPath("~/images/"));
    string[] crop_filesPath = Directory.GetFiles(Server.MapPath("~/images/crop/"));
    List<filenames> files = new List<filenames>();
    filenames objfilenames;
    for(int i=0; i<filesPath.length; i++)
    {
    objfilenames = new filenames();
    objfilenames.filename = "~/images/" +  Path.GetFileName(filesPath[i]);
    objfilenames.crop_filename = "~/images/crop/" + Path.GetFileName(crop_filesPath[i]);
    files.Add(objfilenames);
    }
    gvDetails.DataSource = files;
    gvDetails.DataBind();
    }
