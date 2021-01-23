    class DataGridViewCell: DataGridViewTextBoxCell
    {
            protected override void PaintErrorIcon(Graphics graphics, Rectangle clipBounds, Rectangle cellValueBounds, string errorText)
            {
                if(errorText == "linked")
                {
                    graphics.DrawIcon(SystemIcons.Error, new Rectangle(cellValueBounds.Width - 10, 0, 10, 10));
                }
                else 
                {
                    // base method
                }
            }    
    }
