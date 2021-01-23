    class SoundButton : Button
    {
        public Uri ButtonTapSound
        {
            get { return (Uri)GetValue(ButtonTapSoundProperty); }
            set { SetValue(ButtonTapSoundProperty, value); }
        }
        public static readonly DependencyProperty ButtonTapSoundProperty =
            DependencyProperty.Register("ButtonTapSound", typeof(Uri), typeof(SoundButton), new PropertyMetadata(default(Uri), new PropertyChangedCallback(OnUriChanged)));
        private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           //Your code
        }
    }
