       class FrameRenderer : INotifyPropertyChanged
    {
        private BitmapSource _Bitmap;
        public BitmapSource Bitmap
        {
            get
            {
                return _Bitmap;
            }
            private set
            {
                _Bitmap = value; 
                OnPropertyChanged("Bitmap");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;       
        
        private void OnPropertyChanged(String info)
        {
           
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {               
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"UI Runtime Exception:" + ex.Message);
                }
            }
        }
        public void SetBitmap(BitmapSource bitmap) {
            bitmap.Freeze();
            Bitmap = bitmap;
            GC.Collect();
        }
    }
