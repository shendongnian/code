        private void GetPanelControls()
        {
            foreach (Control formControl in this.Controls)
            {
                if (formControl is Panel)
                {
                    string panelName = ItemsIDSelected[panelnamecounter] + "p";
                    if (formControl.Name == panelName)
                    {
                        foreach (Control item in formControl.Controls)
                        {
                            // Your Code
                        }
                    }
                }
            }
        }
