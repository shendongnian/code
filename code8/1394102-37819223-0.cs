    private void DataGridAutoGeneratingColumnHandler(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Connected")
        {
            var c = e.Column as DataGridCheckBoxColumn;
            if (c == null)
                return;
            c.IsReadOnly = true;
            c.ElementStyle =
                new Style
                {
                    TargetType = typeof (CheckBox),
                    Setters =
                    {
                        new Setter { Property = ContentProperty, Value = "Disconnected" },
                        // prevent checking CheckBoxes 
                        new Setter { Property = IsHitTestVisibleProperty, Value = false },
                    },
                    Triggers =
                    {
                        new Trigger
                        {                                
                            Property = CheckBox.IsCheckedProperty, 
                            Value = true,
                            Setters =
                            {
                                new Setter { Property = ContentProperty, Value = "Connected" }
                            }
                        }
                    }
                };
        }
    }
