    private void LstBox_OnPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListBoxItem ListBoxItem = (ListBoxItem)(lstBox.ItemContainerGenerator.ContainerFromIndex(lstBox.SelectedIndex));
        ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(ListBoxItem);
        DataTemplate myDataTemplate = contentPresenter.ContentTemplate;
        StackPanel temp = (StackPanel)myDataTemplate.FindName("myStackPanel", contentPresenter);
        //*so as to do some further operations like make the textbox editable and so on* as you want
       (temp.FindName("field1TextBox") as TextBox).IsReadOnly = false;
    }
