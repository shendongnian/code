    class ClickableImage : Image
    {
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        
        /* public ClickableImage()
        {
            tapGestureRecognizer.Tapped += (s, e) => {
                System.Diagnostics.Debug.WriteLine("Image Clicked");
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
        } */
        public ClickableImage(Action action)
        {
            tapGestureRecognizer.Tapped += (s, e) => {
                System.Diagnostics.Debug.WriteLine("Image Clicked w/ Lambda");
                action();
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
