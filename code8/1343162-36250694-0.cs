        public partial class MainPage : System.Web.UI.Page
        {
            Random rd = new Random();
            private PageState _pageState;
            protected void Page_Load(object source, EventArgs e)
            {
                _pageState = ViewState["pageState"] as PageState ?? new PageState();
            }
            protected void Page_PreRender(object sender, EventArgs e)
            {
                ViewState["pageState"] = _pageState;
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                int rn = rd.Next(1, 1000);
                if (rn > 1 && rn < 50)
                {
                    Label1.Text = "3";
                    _pageState.threeint++;
                    threelbl.Text = _pageState.threeint.ToString();
                }
                if (rn > 50 && rn < 500)
                {
                    Label1.Text = "2";
                    _pageState.twoint++;
                    twolbl.Text = _pageState.twoint.ToString();
                }
                if (rn > 500 && rn < 1000)
                {
                    Label1.Text = "1";
                    _pageState.oneint++;
                    onelbl.Text = _pageState.oneint.ToString();
                }
            }
        }
    
        [Serializable]
        public class PageState
        {
            public int oneint { get; set; }
            public int twoint { get; set; }
            public int threeint { get; set; }
        }
