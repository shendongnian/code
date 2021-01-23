    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new[]{
                new DataObject(){
                    ItemA = "&lt;div&gt;Item 1&lt;/div&gt;",
                    ItemB = "&lt;div&gt;Item 2&lt;/div&gt;"
                }
            };
    
            myFormView.DataSource = data;
            myFormView.DataBind();
    
            
        }
    
        protected void myFormView_DataBound(object sender, EventArgs e)
        {
            var form = (FormView)sender;        
            HtmlDecode(form);
        }
    
        private void HtmlDecode(Control control)
        {
            if (control == null)
                return;
    
            foreach(var child in control.Controls.Cast<Control>())
                HtmlDecode(child);
    
            var textBox = control as TextBox;
    
            if (textBox == null)
                return;
    
            textBox.Text = HttpUtility.HtmlDecode(textBox.Text);
        }    
    }
    
    public class DataObject 
    {
        public string ItemA { get; set; }
        public string ItemB { get; set; }
    }
