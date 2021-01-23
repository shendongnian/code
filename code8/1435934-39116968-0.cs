     private void timer_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
               if (i < 4 )
                {
    
                    ImageSourceHeader_Image = new BitmapImage(new Uri("pack://application:,,,/Images/" + i.ToString() + ".jpg"));
    
                    ImageSourceHeader_Image.Freeze();                   
                }
                else
                {
                    i = 1;
                    ImageSourceHeader_Image = new BitmapImage(new Uri("pack://application:,,,/Images/" + i.ToString() + ".jpg"));
    
                    ImageSourceHeader_Image.Freeze();
    
                }
                i = i + 1;
    
            });
    
        }
