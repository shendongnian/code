    private void KeypadButtonClick(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;
            if (currentButton != null)
            {
                string buttonContentValue = currentButton.Content.ToString();
                PlayTargetKeypadSound(buttonContentValue);
                RefreshNumber(buttonContentValue);
            }
        }
        private void PlayTargetKeypadSound(string buttonContentValue)
        {
            String path = "/Assets/Sounds/keyNumber_" + buttonContentValue + ".wav";
            KeySoundMediaElement.MediaOpened += KeySoundMediaElementOnMediaOpened;
            KeySoundMediaElement.Source = new Uri(path, UriKind.RelativeOrAbsolute);
        }
        private void KeySoundMediaElementOnMediaOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            MediaElement sound = sender as MediaElement;
            if (sound != null) sound.Play();
        }
        private void RefreshNumber(string buttonContentValue)
        {
            NumberTextBlock.Text = buttonContentValue;
        }
