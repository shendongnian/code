    public class DataGridViewCustomErrorIconCell : DataGridViewTextBoxCell
        {
            protected override void Paint(
                Graphics graphics,
                Rectangle clipBounds,
                Rectangle cellBounds,
                int rowIndex,
                DataGridViewElementStates cellState,
                object value,
                object formattedValue,
                string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                // No matter what, do not let the base class see the ErrorIcon Flag. So remove it. The PaintErrorIcon method will never be called by the based class.
                // A benefit of doing this allows us to NOT set DataGridView.ShowErrorIcons = false. (e.g. other cell types will use the default implemention of error icon. 
                // However, JUST FOR THIS COLUMN OF CELLS, we will implement our own call to PainErrorIcon.
                paintParts ^= DataGridViewPaintParts.ErrorIcon; //Removes the flag.
    
                // Call the base class method to paint the default cell appearance.
                // Since we removed the errorIcon flag, the icon will NEVER EVER EVER be painted for this cell type. 
                // Cool. We will do it ourselves.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                    value, formattedValue, errorText, cellStyle,
                    advancedBorderStyle, paintParts);
    
                // Since we have removed the ErrorIcon painPart, let's implement the call to PaintErrorIcon ourselves.
                // Note: When using reflector, I saw the base class also checks for the existence of the errorText parameter and if so, calls PaintErrorIcon. (however, with other internal parameters that keep our override from being called. There is a private void PaintPrivate(...) method in the base class that takes 2 extra parameters of type bool called 'computeContentBounds' and 'computeErrorBounds'. And then lots of "if" conditions. 
                if (!string.IsNullOrEmpty(errorText))
                {
                    var errorIconBounds = ComputeErrorIconBounds(cellBounds); // As copied from the base class when using reflector.
                    PaintErrorIcon(graphics, clipBounds, errorIconBounds, errorText);
                }
            }
    
            protected override void PaintErrorIcon(Graphics graphics, Rectangle clipBounds, Rectangle errorIconBounds, string errorText)
            {
                // You can use something built-in, such as:
                // graphics.DrawIcon(System.Drawing.SystemIcons.Asterisk, errorIconBounds);
    
                // *** OR: you can Bob Ross it up and create your own canvas and draw whatever pretty pictures you want, given the errorIconBounds.
                var iconCanvas = new Bitmap(errorIconBounds.Width, errorIconBounds.Height);
                var iconArtist = Graphics.FromImage(iconCanvas); // this artist is assigned to the given canvas.
    
                // Tell the artist draw something, using a RED brush. Not creative, maybe a Jurassic park video brush? "Uh, uh, uh..."
                iconArtist.DrawString("X", new Font(this.InheritedStyle.Font.FontFamily, 12, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Red, 0, 0);
    
                // Then draw that canvas to the error icon bounds.
                graphics.DrawImage(iconCanvas, errorIconBounds);
    
            }
    
            private Rectangle ComputeErrorIconBounds(Rectangle cellValueBounds)
            {
                // 12, and 11 are the "defaults" found when reflecting DataGridViewCell and found internal static properties.
                int defaultWidth = 12, defaultHeight = 11;
    
                if (cellValueBounds.Width < 8 + defaultWidth || cellValueBounds.Height < 8 + defaultHeight)
                {
                    return Rectangle.Empty;
                }
    
                Rectangle rectangle = new Rectangle((cellValueBounds.Right - 4 - defaultWidth), cellValueBounds.Y + (cellValueBounds.Height - defaultHeight) / 2, (int)defaultWidth, (int)defaultHeight);
                return rectangle;
            }
        }
    
        public class DataGridViewCustomErrorIconColumn : DataGridViewTextBoxColumn
        {
            public DataGridViewCustomErrorIconColumn()
            {
                this.CellTemplate = new DataGridViewCustomErrorIconCell();
            }
        }
