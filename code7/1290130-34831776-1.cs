    for (int i = 0; i < yourListBox.Items.Count; i++)
    {
        ListBoxItem yourListBoxItem = (ListBoxItem)(yourListBox.ItemContainerGenerator.ContainerFromIndex(i));
        ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(yourListBoxItem);
        DataTemplate myDataTemplate = contentPresenter.ContentTemplate;
        EditableTextBlock editable = (EditableTextBlock) myDataTemplate.FindName("editableTextBlock", contentPresenter);
        //Do stuff with EditableTextBlock
        editable.IsInEditMode = true;
    }
