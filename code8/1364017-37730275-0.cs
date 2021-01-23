        // You can also use BitmapImage directly, if you'd like to make reloading faster and don't care memory usage.
        private WeakReference<BitmapImage> image;
        public BitmapImage Image
        {
            get
            {
                BitmapImage image;
                if(this.image != null && this.image.TryGetTarget(out image))
                    return image;
                image = new BitmapImage();
                this.image = new WeakReference<BitmapImage>(image);
                var ignore = Task.Run(()=>
                {
                    //Load image here.
                    //Don't forget to use Dispatcher while calling SetSourceAsync() or setting Source.
                });
                return image;
            }
        }
