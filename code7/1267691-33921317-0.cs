    List<TextBlock> tList = new List<TextBlock>();
    for (int j = 0; j < myList.Count; j++)
    {
       tList.Add(new TextBlock()
       {
          Text = myList[j].TitleView,
          Foreground = new SolidColorBrush(Windows.UI.Colors.White)
                    
       });
    }
     tileGridView.ItemsSource = myList;
     tileGridView.ItemsSource = tList;
