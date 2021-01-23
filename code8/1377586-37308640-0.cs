    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TimeSpan startTime = new TimeSpan(0, 0, 0);
            TimeSpan endTime = new TimeSpan(1, 0, 0);
            int i = 0; 
                       
            While(startTime <= endTime)
            {
                i++;
                CreateControl(startTime.ToString(@"hh\:mm\:ss"), i);
                startTime += TimeSpan.FromMinutes(15); //Add 15 minutes
            }
        }
        void CreateControl(string printTime, increment)
        {
            Button btn1 = new Button();
            btn1.ID = "btn_" + increment;
            btn1.Text = printTime;
            btn1.Click += new EventHandler(btn_Click);
            div1.Controls.Add(btn1);
        }
        void btn_Click(object sender, EventArgs e)
        {
            string ID = (sender as Button).ID;
            div1.InnerHtml += "btn " + ID + " was clicked";
        }
    }
