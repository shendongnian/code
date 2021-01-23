    public partial class TableRepeaterExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var answer1 = new Answer { Option = "A", AnswerText = "" };
                var answer2 = new Answer { Option = "B", AnswerText = "" };
                var answer3 = new Answer { Option = "C", AnswerText = "" };
                
                Repeater1.DataSource = new List<Answer> { answer1, answer2, answer3 };
                Repeater1.DataBind();
            }
        }
        protected void mn_ServerClick(object sender, EventArgs e)
        {
            foreach(RepeaterItem item in Repeater1.Items)
            {
                TextBox txtAnswer = item.FindControl("txtAnswer") as TextBox;
                if(txtAnswer != null)
                {
                    string answer = txtAnswer.Text;
                }
            }
        }
    }
    public class Answer
    {
        public string Option { get; set; }
        public string AnswerText { get; set; }
    }
