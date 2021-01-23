        public static readonly DependencyProperty NestedItemsProperty = DependencyProperty.Register("NestedItems", typeof(string), typeof(TextDocumentEditor),
            new PropertyMetadata((string)null));
        public static readonly DependencyProperty NestedDataTemplateProperty = DependencyProperty.Register("NestedDataTemplate", typeof(DataTemplate), typeof(TextDocumentEditor),
            new PropertyMetadata((DataTemplate)null));
        public DataTemplate NestedDataTemplate
        {
            get { return (DataTemplate)GetValue(NestedDataTemplateProperty); }
            set
            {
                SetValue(NestedDataTemplateProperty, value);
            }
        }
        public string NestedItems
        {
            get { return (string)GetValue(NestedItemsProperty); }
            set
            {
                SetValue(NestedItemsProperty, value);
            }
        }
        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (((ItemContainerGenerator)sender).Status != GeneratorStatus.ContainersGenerated)
                return;
            ContentPresenter value;
            ItemsControl itemsControl;
            for (int x=0;x<ItemContainerGenerator.Items.Count; x++)
            {
                value = ItemContainerGenerator.ContainerFromIndex(x) as ContentPresenter;
                if (value == null)
                    continue;
                value.ApplyTemplate();
                itemsControl = value.GetChildren<ItemsControl>().FirstOrDefault();
                if (itemsControl != null)
                {
                    if (NestedDataTemplate != null)
                        itemsControl.ItemTemplate = NestedDataTemplate;
                    Binding binding = new Binding(NestedItems);
                    BindingOperations.SetBinding(itemsControl, ItemsSourceProperty, binding);
                }
            }
        }
