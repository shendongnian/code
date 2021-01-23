    if (localSettings_CycleLength.Values.ContainsKey("CycleLength"))
                {
                    var item = localSettings_CycleLength.Values["CycleLength"]; ;
                    foreach(var items in CLengthCombo.Items)
                    {
                        if((items as ComboBoxItem).Content.Equals(item))
                        {
                            this.CLengthCombo.SelectedItem = items;
                        }
                    }
                }
