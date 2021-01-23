    private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
               
                var source = e.OriginalSource as FrameworkElement;
                var mainViewModel = DataContext as MainViewModel;
                if (source != null)
                {
                    var model = source.DataContext as SelectionItemViewModel;
                    model.IsSelected = !model.IsSelected;
                    if (model != null)
                    {
                        foreach (var m in mainViewModel.Items.Where(i => i.Value.Id == model.Value.Id && model != i))
                        {
                            if (m.IsSelected != model.IsSelected)
                            {
                                m.IsSelected = model.IsSelected;
                            }
                        }
                    }
                }
            }
