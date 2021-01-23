    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var questions = GetQuestions();
                rpt.DataSource = questions;
                rpt.DataBind();
            }
        }
        private IEnumerable<Question> GetQuestions()
        {
            // Load questions from database
            // Setting up some sample data for this sample
            var lst = new List<Question>();
            return Enumerable.Range(1, 5).Select(x => new Question() { Id = x, Text = "Question " + x.ToString() });
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var dictAnswers = GetValuesFromRepeater();
            // Save answers to database
        }
        private IDictionary<int, int> GetValuesFromRepeater()
        {
            var dict = new Dictionary<int, int>();
            foreach (RepeaterItem item in rpt.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var id = int.Parse(((HiddenField)item.FindControl("hiddenId")).Value);
                    var answer = int.Parse(((DropDownList)item.FindControl("ddlAnswer")).Text);
                    dict.Add(id, answer);
                }
            }
            return dict;
        }
    }
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
