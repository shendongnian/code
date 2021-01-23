    class LabelColumn : ITemplate
    {
        int i;
        public LabelColumn(int i)
        {
            this.i = i;
        }
        public void InstantiateIn(Control container)
        {
            Label label = new Label();
            label.ID = "lblSecondHalf" + i;
            label.DataBinding += new EventHandler(label_DataBinding);
            container.Controls.Add(label);
        }
        private void label_DataBinding(Object sender, EventArgs e)
        {
            Label label = (Label)sender;
            GridViewRow row = (GridViewRow)label.NamingContainer;
            label.Text = DataBinder.Eval(row.DataItem, "SecondHalf" + i).ToString();
        }
    }
