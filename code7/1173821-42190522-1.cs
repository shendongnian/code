    public page()
    {
        string[] items = {"Item 1","Item 2",......."Item n"}
        var itemsGrid = new Grid();
        int k = 1 + Items.Length / 3;
        // just to make it clear in the for loop i used (int k)  
        // suppose 3 column need we divide on 3
            
        // define the number of rows according to the number of item you have
        for (int i = 0; i <k ; i++)
        {
                itemsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        }
        // defining column number (in this case 3)
        for (int j = 0; j < 3; j++)
        {
                itemsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        // adding the items to the grid (3 column , RN rows)
        int RN = 0;  // initializing the row number 
        for (int num = 0; num < Fruits.Length; num++)
        {
                if (num % 3 == 0)     // first column
                {
                    itemsGrid.Children.Add(new Label()  // adding the item as label
                    {
                        Text = Items[num],
                        TextColor = Color.White,
                        BackgroundColor = Color.Blue,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, RN);
                }
                else if (num % 3 == 1)// second column
                {
                    itemsGrid.Children.Add(new Label()
                    {
                        Text = Items[num],
                        TextColor = Color.White,
                        BackgroundColor = Color.Blue,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    }, 1, RN);
                }
                else  //third column
                {
                    itemsGrid.Children.Add(new Label()
                    {
                        Text = Items[num],
                        TextColor = Color.White,
                        BackgroundColor = Color.Blue,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    }, 2, RN);
                    RN++;
                }
            }
        }
        
