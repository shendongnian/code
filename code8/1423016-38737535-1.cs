        private void playlistTimer_Tick1a(object sender, object e)
        {
            if (Images1a != null)
            {
                //set the topBanner's image source here
                topBanner.Source = new BitmapImage(new Uri(Images1a[count1a]));
                if (count1a < Images1a.Count)
                    count1a++;
                if (count1a >= Images1a.Count)
                    count1a = 0;
                ImageRotation1a();
            }
        }
