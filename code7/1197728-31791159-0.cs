    private void SetScrolling(CustomEditor view){
        var scroll = new ScrollViewer{Content = Control};
        var index = Children.IndexOf(Control);
        if(index != -1)
            Children.RemoveAt(index);
        Children.Add(scroll);
    }
