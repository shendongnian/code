<!-- -->
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (DesignMode)
                    return;
    
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        DoDragDrop(PointedTabPage, DragDropEffects.Move);                    
    
                        break;
                    case MouseButtons.Middle:
                        TabPages.Remove(PointedTabPage);
                        break;
                }
            }
    
            #endregion
