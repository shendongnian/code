    for (int i=1;i<11;i++)
    {
        TextBlock txtName = new TextBlock();
        txtName.Name = i.ToString();
        txtName.Tapped += TxtName_Tapped;
    }
    
    private void TxtName_Tapped(object sender, TappedRoutedEventArgs e)
    {
        TextBlock textBlock = sender as TextBlock;
        switch(textBlock.Name)
        {    
             // list possible cases
             case "1":
             {
                 // do something 
             }
        }
    }
