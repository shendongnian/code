    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomPanel runat=server></{0}:CustomPanel>")]
    public class CustomPanel : Panel
    {
        [Bindable(true)]
        public object MyDataSource
        {
            get;
            set;
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public StringBuilder Text
        {
            get;
            set;
        }
        public void MyDataBind()
        {
            Text = new StringBuilder();
            foreach (PropertyInfo p in MyDataSource.GetType().GetProperties())
            {
                Text.Append(string.Format("<b>{0}</b>", p.Name));
                Text.Append(":");
                if (p.GetIndexParameters() == null || p.GetIndexParameters().Length == 0)
                    Text.Append(p.GetValue(MyDataSource, null));
                Text.Append("<br />");
            }
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
