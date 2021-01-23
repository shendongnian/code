    public partial class PageOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void CustomCheckBox1_OnCheckChanged(object sender, CheckBoxEventArgs e)
        {
            var val1 = e.ValueOne;
            var val2 = e.ValueTwo;
            //use custom values
        }
    }
