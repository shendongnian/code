    ///////////////AUCTION MAIN WINDOW START///////////////////////
    //Global variable
    string strIsAdmin;
    public frmAuctionMainWindow(string isAdmin)
        {
            InitializeComponent();
            strIsAdmin = isAdmin;
        }
    //strIsAdmin tells you whther or not they are admin so on form load just make them visible or not visible accordingly...
    private frmAuctionMainWindow_Load(object sender, EventArgs e)
    {
        if(strIsAdmin == "1")
        {
            //User is admin
        }     
        else if(strIsAdmin == "0")
        {
            //User is not admin...(could use else statement if only logged users are visiting this form
        }
    }
    ///////////////AUCTION MAIN WINDOW END///////////////////////
    ///////////////LOGIN FORM START//////////////////////////////
    
        //Button could only be visible to people who have access (logged in users)
    private void btnOpenMain(object sender, EventArgs e)
    {
        frmAuctionMainWindow main = new frmAuctionMainWindow(isAdmin);
        main.Show(); //Or main.ShowDialog(); depending on what you want
          
    }
    ///////////////LOGIN FORM END////////////////////////////////
