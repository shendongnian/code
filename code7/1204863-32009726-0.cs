      foreach (Control ctrl in stkContainer.Children)
                {
                    if (ctrl.GetType() == typeof(ComboBox))
                    {
                        ComboBox cbo = ctrl as ComboBox;
                        ClearAllComboboxes(cbo);
                    }
                }
