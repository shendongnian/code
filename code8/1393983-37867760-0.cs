    public class PalleteGeneration : Java.Lang.Object, Palette.IPaletteAsyncListener
    {
        private MyView _holder;
    
        public PalleteGeneration(MyView holder) 
        
            _holder = holder;
        }
    
        public void OnGenerated(Palette palette)
        {
            if (palette == null)
                return;
           
            if (palette.LightVibrantSwatch != null)
            {
                var lightVibrant = new Color(palette.LightVibrantSwatch.Rgb);
                _holder.mCard.SetCardBackgroundColor(lightVibrant);
               
            }
            else if (palette.LightMutedSwatch != null)
            {
                var lightVibrant = new Color(palette.LightMutedSwatch.Rgb);
                _holder.mCard.SetCardBackgroundColor(lightVibrant);
    
            }
            if (palette.DarkVibrantSwatch != null)
            {
                var darkVibrant = new Color(palette.DarkVibrantSwatch.Rgb);
                _holder.TitleBackground.SetBackgroundColor(darkVibrant);
            }
            else if (palette.DarkMutedSwatch != null)
            {
                var darkVibrant = new Color(palette.DarkMutedSwatch.Rgb);
                _holder.TitleBackground.SetBackgroundColor(darkVibrant);
            }               
    }
