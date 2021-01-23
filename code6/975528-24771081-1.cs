    foreach (TabPage TPage in ShiftsViewTab.TabPages)
                {
                    if (TPage.Name.Equals("tabPage2"))
                    {
                        var TabPageControlls = TPage.Controls;
                        foreach( Control _C in TabPageControlls)
                        if (_C is CheckedListBox)
                        {
                            ((CheckedListBox)_C).Items.Clear();
                            foreach (string _Val in Settings.Default.ShiftList)
                            {
                                ((CheckedListBox)_C).Items.Add(_Val);
                            }
                        }
                    }
                    
                }
