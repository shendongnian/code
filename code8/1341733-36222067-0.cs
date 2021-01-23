      while (i < blauw)
                    {
                        var bool= await checkImage(i); //checks if it has the attribute or not
                        ImageBrush brush = new ImageBrush();
                        Button Btn = new Button();
                        Uri uri = new Uri("ms-appx://Blijfie/images/" + selected + "/" + blauwpics[i]);
                        BitmapImage imgSource = new BitmapImage(uri);
                        brush.ImageSource = imgSource;
                        Btn.Background = brush;
                        Btn.Width = 200;
                        Btn.Height = 200;
    
                        if (i >= 5 && i < 10)
                        {
                            Canvas.SetTop(Btn, marginTop);
                            Canvas.SetLeft(Btn, marginLeft2);
                            marginLeft2 = marginLeft2 + 250;
                        }
                        else if (i < 6)
                        {
                            Canvas.SetLeft(Btn, marginLeft);
                            marginLeft = marginLeft + 250;
    
                        }
                        else if (i >= 10)
                        {
                            Canvas.SetTop(Btn, marginTop2);
                            Canvas.SetLeft(Btn, marginLeft3);
                            marginLeft3 = marginLeft3 + 250;
                        }
                        main.Children.Add(Btn);
                        i++;
    
                   }
    Private Task<bool> CheckImage(int i)
    {
    Yourcode
    Return true;
    }
