     private void Panel_Drop(object sender, DragEventArgs e)
        {
            Panel panel = sender as Panel;
            if (sourcePanel != null && tmpButton!=null)
            {
                sourcePanel.Children.Remove(tmpButton);
                panel.Children.Add(((UIElement)e.Data.GetData(typeof(Button))));
                sourcePanel = null;
                tmpButton = null;
            }                      
        }
