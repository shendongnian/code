    if (localSettings_CycleLength.Values.ContainsKey("CycleLength"))
                {
                    var savedItem = localSettings_CycleLength.Values["CycleLength"]; ;
                    foreach(var item in CLengthCombo.Items)
                    {
                        if((item as ComboBoxItem).Content.Equals(savedItem ))
                        {
                            this.CLengthCombo.SelectedItem = item;
                        }
                    }
                }
