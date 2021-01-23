    private static void OnCurrentTimePropertyChanged(DependencyObject source,
        DependencyPropertyChangedEventArgs e)
        {
            TablesForm control = source as TablesForm;
            control.m_viewModel.Log = (string)e.NewValue;            
        }
