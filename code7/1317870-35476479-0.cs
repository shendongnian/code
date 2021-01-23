        protected void Page_Load(object sender, EventArgs e)
        {
            SetAllLabelValue(this.Controls);
        }
        private void SetAllLabelValue(ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                if (item.HasControls())
                {
                    SetAllLabelValue(item.Controls);
                }
                Label lb = item as Label;
                if (lb != null)
                {
                    lb.Visible = false;
                }
            }
        }
