    protected void btn_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        if(btn == null)
            return;
       switch(btn.Name)
       {
           case "btnOne":
              //...
              break;
           case "btnTwo":
              //...
              break;
       }
    }
