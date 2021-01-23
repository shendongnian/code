      private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
      {
         RoutedCommand c = e.Command as RoutedCommand;
         IInputElement parent = this.Parent as IInputElement;
         c.Execute(e.Parameter, parent);
      }
