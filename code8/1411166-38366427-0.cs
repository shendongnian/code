        private void separateContent()
        {
            foreach (News item in AllNews)
            {
                Debug.WriteLine(item.Tag);
                if (item.Tag == "Windows")
                    Windows.Add(item);
                else if (item.Tag == "Apple")
                    Apple.Add(item);
                else if (item.Tag == "Google")
                    Google.Add(item);
                else if (item.Tag == "Other")
                    Other.Add(item);
                else
                    Top.Add(item);
            }
            IntroHead.FontWeight = FontWeights.SemiBold;
            StoryContent.Navigate(typeof(TopNewsPage), Top);
        }
        private void Tags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Top.Count < 6)
                return;
            IntroHead.FontWeight = FontWeights.Normal;
            WindowsHead.FontWeight = FontWeights.Normal;
            AppleHead.FontWeight = FontWeights.Normal;
            GoogleHead.FontWeight = FontWeights.Normal;
            OtherHead.FontWeight = FontWeights.Normal;
            switch (Tags.SelectedIndex)
            {
                case 0:
                    IntroHead.FontWeight = FontWeights.SemiBold;
                    StoryContent.Navigate(typeof(TopNewsPage), Top);
                    break;
                case 1:
                    WindowsHead.FontWeight = FontWeights.SemiBold;
                    StoryContent.Navigate(typeof(OtherNews), Windows);
                    break;
                case 2:
                    AppleHead.FontWeight = FontWeights.SemiBold;
                    StoryContent.Navigate(typeof(OtherNews), Apple);
                    break;
                case 3:
                    GoogleHead.FontWeight = FontWeights.SemiBold;
                    StoryContent.Navigate(typeof(OtherNews), Google);
                    break;
                case 4:
                    OtherHead.FontWeight = FontWeights.SemiBold;
                    StoryContent.Navigate(typeof(OtherNews), Other);
                    break;
            }
        }
