    for (int i = 0; i < Game_ScrollViewer_online.Items.Count; i++)
    {
         ListBoxItem GameListBoxItem = (ListBoxItem)(Game_ScrollViewer_online.ItemContainerGenerator.ContainerFromIndex(i));
         ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(GameListBoxItem);
         DataTemplate myDataTemplate = contentPresenter.ContentTemplate;
         Button tempBut = (Button) myDataTemplate.FindName("Current_game_button", contentPresenter);
         //Do stuff with button
    }
