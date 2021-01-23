    private void someClickEvent(object sender, RoutedEventArgs e)
        {
         var buttonDataContext = (sender as Button).DataContext;
         if(buttonDataContext.isFolder)
         {
           doSomeThing();
         }
         else
         {
         return;
        }
        }
