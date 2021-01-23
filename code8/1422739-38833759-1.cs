    class ClickableImage : Image
    {
        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        public ClickableImage(Action action)
        {
            tapGestureRecognizer.Tapped += (s, e) => 
            {
               System.Diagnostics.Debug.WriteLine("Image Clicked w/ Lambda");
               action();
            };
            GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
