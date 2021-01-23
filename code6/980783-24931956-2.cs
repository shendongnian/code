                private bool InputValidation()
                {
        
                    foreach (Control thisControl in requiredFieldlst) //Required fields and special character validation
                    {
                        if (string.IsNullOrEmpty(((TextBox)thisControl).Text))
                        {
                            //Do not save, show messagebox.
                            MessageBox.Show("Some required Fields are missing....!", "Error", MessageBoxButtons.OK);
                            ((TextBox)thisControl).Focus();
                            return false;
                        }
        
                    }
