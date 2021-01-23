     <Image  Grid.RowSpan="4" HorizontalAlignment="Right" VerticalAlignment="Top" Source="{Binding _contact.bitmapImage}" Stretch="UniformToFill" Margin="5" Width="100" Height="100" Opacity="1" />
      public byte[] Image
        {
            get
            {
                return (_imgBytes);
            }
            set
            {
                _imgBytes = value;
                CreateBitmap();
            }
        }
        private async void CreateBitmap()
        {
            var result = await dbUtils.CreateBitmap(_imgBytes);
            _bitmap = result;
        }
        [Ignore]
        public BitmapImage bitmapImage
        {
            get
            {
                return (_bitmap);
            }
        }
