    public string getSelectedRadioButton()
        {
            string radioSelected = string.Empty;
            foreach (Control control in ulGroup.Controls)
            {
                if (control.GetType().Name.Equals("HtmlInputRadioButton") && (control as HtmlInputRadioButton).Checked)
                {
                    radioSelected = (control as HtmlInputRadioButton).Value; break;
                }
            }
            return radioSelected;
        }
