    public class TextBoxEx : TextBox
    {
        public string Format { get; set; }
    
        private object datasource = new object();
        public object Datasource
        {
            get { return datasource; }
            set 
            {
                datasource = value;
                if (datasource == null)
                    base.Text = string.Empty;
                else if(string.IsNullOrWhiteSpace(Format))
                    base.Text = datasource.ToString();
                else
                    base.Text = string.Format("{0:"+ Format + "}",datasource);
            }
        }
    }
