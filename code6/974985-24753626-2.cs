// Prepare two BitmapImages
BitmapImage SoundDisable = new BitmapImage(new Uri("ms-appx:///png/btn_speak_i.png", 
    UriKind.RelativeOrAbsolute));
BitmapImage SoundEnable = new BitmapImage(new Uri("ms-appx:///png/btn_speak.png", 
    UriKind.RelativeOrAbsolute));
// Define and Load Button
btnSound = new Button();
btnSound.HorizontalAlignment = HorizontalAlignment.Left;
btnSound.VerticalAlignment = VerticalAlignment.Bottom;
Thickness margin = new Thickness(0,00,20,0);
btnSound.Margin = margin;
btnSound.Click += new RoutedEventHandler(btnSound_Click);
btnSound.IsEnabled = false;
    
<strong>var image = new Image();
image.Source = SoundDisable;
btnSound.Content = image;</strong>
    
topBar.Children.Add(btnSound);
