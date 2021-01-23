    if (null != audioPlayerElement.Source)
                        {
                            audioPlayerElement.Stop();
                            FrameworkElement elem = this.ContentPanel.FindName(audioPlayerElement.Tag.ToString()) as FrameworkElement;
                            RelativePanel audioPanel = elem as RelativePanel;
                            Button playButton = (from im in audioPanel.Children.OfType<Button>() select im).FirstOrDefault();
                            playButton.Tag = "PAUSED";
                            ImageBrush backgroundImage = new ImageBrush();
                            backgroundImage.ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Video_Play_button.png"));
                            backgroundImage.Stretch = Stretch.None;
                            playButton.Background = backgroundImage;
                            Slider prevSlider = (from im in audioPanel.Children.OfType<Slider>() select im).FirstOrDefault();
                            prevSlider.Value = 0;
                        }
audioPlayerElement = audioElement;
