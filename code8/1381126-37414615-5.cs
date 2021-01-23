    private void ResetButton(double selectedButtonID)
            {
                List<string> createdControls = Session["Controls"] != null ? Session["Controls"] as List<string> : new List<string>();
                TimeSpan timespan = TimeSpan.FromHours(selectedButtonID);
                string currentSelectedTime = timespan.ToString("h\\:mm");
                foreach (string buttonID in createdControls)
                {
                    if (!string.IsNullOrEmpty(buttonID))
                    {
                        int comparisonResult = timespan.CompareTo(TimeSpan.FromHours(Convert.ToDouble(buttonID)));
                        Button button = Page.FindControl(buttonID) as Button;
                        if (button != null && comparisonResult==1)
                        {
                            button.BackColor = Color.Yellow;// selected
                        }
                        else
                        {
                            button.BackColor = Color.Red;// deselected
                        }
                    }
                }
