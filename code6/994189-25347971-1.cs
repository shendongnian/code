        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null && b.Tag != null)
            {
                Type pageType = Type.GetType(b.Tag.ToString());
                if (pageType != null)
                {
                    if (rootFrame.CurrentSourcePageType != pageType)
                    {
                        // No goBack for Basic Pages
                        if (testBasicPage(pageType))
                        {
                            while (rootFrame.BackStackDepth > 0)
                            {
                                rootFrame.BackStack.RemoveAt(0);
                            }
                        }
                        rootFrame.Navigate(pageType, rootFrame); 
                    }
                }
            }
        }
