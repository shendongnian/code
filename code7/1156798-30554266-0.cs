     <ListView tools:ListViewExtension.FilterSource="{Binding ElementName=txtFilter,Path=Text,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
    public static readonly DependencyProperty FilterSourceProperty =
      DependencyProperty.RegisterAttached("FilterSource", typeof(string), typeof(Extentions),
            new FrameworkPropertyMetadata(null, OnTextBoxSet));
    public static string GetFilterSource(DependencyObject dObj)
    {
       return (string)dObj.GetValue(FilterSourceProperty);
    }
    public static void SetFilterSource(DependencyObject dObj, string value)
    {
        dObj.SetValue(FilterSourceProperty, value);
    }
    private static void OnTextBoxSet(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
    {
        var listView = dObj as ListView;
        var textBox = e.NewValue as string;
        if ((listView != null) && (textBox != null))
        {
            var view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            if (view == null) return;
            view.Filter += item => view.SourceCollection.OfType<Employee>().Any(x => x.UserName == textBox);
        }
    }
