        private void ResetButton()
        {
            List<string> createdControls = Session["Controls"] != null ? Session["Controls"] as List<string> : new List<string>();
            foreach (string buttonID in createdControls)
            {
                if (!string.IsNullOrEmpty(buttonID))
                {
                    Button button = Page.FindControl(buttonID) as Button;
                    if (button != null)
                    {
                        button.BackColor = Color.Red;
                    }
                }
            }
        }
