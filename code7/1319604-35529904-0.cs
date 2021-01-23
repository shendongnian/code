    private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
    {
        var uiElement = sender as UIElement;
    
        if (uiElement != null)
        {
            uiElement.Effect = new BlurEffect();
        }
    }
    
    private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
    {
        var uiElement = sender as UIElement;
    
        if (uiElement != null)
        {
            uiElement.Effect = null;
        }
    }
