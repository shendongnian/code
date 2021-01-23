       public partial class NestedForm_Question : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                SubmitButton.Click += SubmitButton_Click;
            }
    
            void SubmitButton_Click(object sender, EventArgs e)
            {
                Literal1.Text = "form submit";
            }
        }
