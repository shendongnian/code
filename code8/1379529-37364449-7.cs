    private string argumentParsedIn = string.empty; //This is the member variable
    Public Form1() : System.Windows.Forms.Form
    {
       InitializeComponent();
    }
    
    Public Form1(string argument) : base() //<-- see here, adding the base will call the base constructor
    {
       argumentParsedIn = argument;
    }
