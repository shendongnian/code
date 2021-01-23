    public class ImageScalingDrawFilter : IUIElementDrawFilter
    {
        bool IUIElementDrawFilter.DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            switch (drawPhase)
            {
                case DrawPhase.BeforeDrawImage:
                    ImageUIElement imageElement = (ImageUIElement)drawParams.Element;
                    Image image = imageElement.Image;                    
                    int availableHeight = drawParams.Element.RectInsideBorders.Height;
                    float ratio = (float)availableHeight / (float)image.Height;
                    float newHeight = image.Height * ratio;
                    float newWidth = image.Width * ratio;
                    Rectangle rect = new Rectangle(
                        imageElement.Rect.X,
                        imageElement.Rect.Y,
                        (int)(newWidth),
                        (int)(newHeight)
                        
                        );
                    // Draw the scaled image.
                    drawParams.Graphics.DrawImage(image, rect);
                    // This tells the grid not to draw the image (since we've already drawn it). 
                    return true;
            }
            return false;
        }
        DrawPhase IUIElementDrawFilter.GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            UIElement element = drawParams.Element;
            // Look for an ImageUIElement
            if (element is ImageUIElement)
            {
                // Presumably, we only want to this images in cells
                // and not every image in the entire grid, so make sure it's in a cell.
                CellUIElement cellElement = element.GetAncestor(typeof(CellUIElement)) as CellUIElement;
                if (null != cellElement)
                {
                    // We could also limit this to a particular column or columns.
                    switch (cellElement.Cell.Column.Key)
                    {
                        case "Image":
                            return DrawPhase.BeforeDrawImage;
                    }
                }
            }
            return DrawPhase.None;
        }
    }
