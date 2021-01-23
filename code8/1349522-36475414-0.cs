     private void CanAddCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (VisualTreeHelper.GetChild(Adding))
            
            {
                e.CanExecute = true;
                //for (int i = 0; i < VisualTreeHelper.GetChildrenCount(Adding); i++)
                //{
                //    var child = VisualTreeHelper.GetChild(Adding, i);
                //    if (Validation.GetHasError(child)) { e.CanExecute = false; }
                //}
                if (Adding != null)
                {
                    for (int i = 0; i < Adding.Children.Count; i++)
                    {
                        var child = Adding.Children[i];
                        if (Validation.GetHasError(child)) { e.CanExecute = false; break; }
                    }
                }
                else e.CanExecute = false;
            }
            
        }
     private void CanSaveCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lst != null)
            {
                if (list.Changes == true)
                    e.CanExecute = true;
                else e.CanExecute = false;
            }
            else e.CanExecute = false;
        }
    private void CanDeleteCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lst != null)
            {
                if (((Researcher)this.lst.SelectedItem) != null) e.CanExecute = true;
            }
            else e.CanExecute = false;
        }
