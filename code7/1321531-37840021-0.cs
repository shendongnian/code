            if (e.CellElement is GridHeaderCellElement)
            {
                if ((((string)(e.CellElement).Value) == "January" || ((string)(e.CellElement).Value) == "Feberuary" || ((string)(e.CellElement).Value) == "March"))
                {
                    e.CellElement.Font = BOLD_FONT;//the font u want
                   
                    e.CellElement.ForeColor = Color.SteelBlue;
                    e.CellElement.GradientStyle = GradientStyles.Solid;
                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.White;
                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                }
            }
        }
