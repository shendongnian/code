    if (e.OriginalSource == tabControl) //if this event fired from your tabControl
                {
                    e.Handled = true;
                    
                    if (!forbiddenPage.IsSelected)  //User leaving the tab
                    {
                        if (forbiddenTest())
                        {
                            forbiddenPage.IsSelected = true;
                            MessageBox.Show("you must not leave this page");
                        }
                 }
