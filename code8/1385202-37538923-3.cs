    protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
               char lowerCase;
               lowerCase = Convert.ToChar(RandomLetter.GetLetter());
               lblStop.Text = lowerCase.ToString();
    
               GenRandomNumber();
            }
        }
