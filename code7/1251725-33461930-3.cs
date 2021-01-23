    private void Questions_Click(object sender, RoutedEventArgs e)
    {
        //The relevant page you want to load
        QuestionsPage questionsPage = new QuestionsPage();
        MainFrame.NavigationService.Navigate(questionsPage);
        //Also you can use Frame.Navigate Method
        //MainFrame.Navigate(questionsPage);
    }
