            protected override void OnInitialized(EventArgs e)
            {
                base.OnInitialized(e);
    
                CloneColumn.Visibility = ShowCloneColumn ? Visibility.Visible : Visibility.Hidden;
            }
    
            private DataGridTemplateColumn _cloneColumn;
            private DataGridTemplateColumn CloneColumn
            {
                get
                {
                    if (_cloneColumn == null)
                    {
                        _cloneColumn = new DataGridTemplateColumn
                        {
                            Header = string.Empty,
                            Visibility = ShowCloneColumn ? Visibility.Visible : Visibility.Hidden
                        };
                        FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof (Button));
                        buttonFactory.SetValue(Button.ContentProperty, "Clone");
                        buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloneButtonClicked));
                        DataTemplate textTemplate = new DataTemplate {VisualTree = buttonFactory};
                        _cloneColumn.CellTemplate = textTemplate;
                        Columns.Add(_cloneColumn);
                    }
                    return _cloneColumn;
                }
            }
