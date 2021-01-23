    private void ModTab_PreviewMouseLeftButtonUp(object sender,
                                                 MouseButtonEventArgs e)
    {
       FrameworkElement link = e.OriginalSource as FrameworkElement;
       if(link != null)
       {
          if(link.Name == "BreedLink")
          {
             ......
          }
          else if (link.Name == "SpecieLink")
          {
             ......
          }
       }
    }
