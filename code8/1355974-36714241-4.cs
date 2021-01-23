    private void Button_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DataObject data = new DataObject(DataFormats.Serializable, (Button)e.Source );
        DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Move);
    }
    
    private void Button_DragEnter(object sender, DragEventArgs e)
    {
        Button btn_to_move = (Button) e.Data.GetData(DataFormats.Serializable);
                
        int where_to_move = Pnl.Children.IndexOf((UIElement)e.Source);
        int what_to_move = Pnl.Children.IndexOf(btn_to_move);
    
        Pnl.Children.RemoveAt(what_to_move);
        Pnl.Children.Insert(where_to_move, btn_to_move);
    }
