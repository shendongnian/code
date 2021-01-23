      void TabItemControl_DataContextChanged(object sender,
         DependencyPropertyChangedEventArgs e)
      {
         ((TabViewModel)DataContext).AskCollection = (CollectionViewSource)Resources["AskDepthCollection"];
         ((TabViewModel)DataContext).BidCollection = (CollectionViewSource)Resources["BidDepthCollection"];
      }
