    public partial class Index : System.Web.UI.Page
    {
       private string str = "";
       protected void Page_Load(object sender, EventArgs e)
       {
          hfm mymaster = (hfm)Page.Master;
          lcont lc = mymaster.getlcont();
          lc.myevent += delegate(string st)
          {
              //slbl.Text = st;
             str =st;
          }
       }
       protectd void myfun()
       {
         //i want to access the string value "st" here.
         
         //value of st has been passed to str already in page_load.
         string newString = str;
       }
    }
