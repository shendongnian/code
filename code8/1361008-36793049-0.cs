    protected void Page_Load(object sender, EventArgs e)
    {
     if(!Page.IsPostBack)
     {
       RijndaelManaged aesAlg = new RijndaelManaged();
       aesAlg.GenerateKey();
       aesAlg.GenerateIV();
       key = aesAlg.Key;
       iv = aesAlg.IV;
     }
    }
