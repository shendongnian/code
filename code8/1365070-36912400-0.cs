         Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                // Check if we are on the entry page and try to go back
                var backTypePage = rootFrame.BackStack[rootFrame.BackStackDepth - 1];
                if (this.EntryPage != null && backTypePage.SourcePageType == this.EntryPage)
                {
                    e.Handled = false;
                    rootFrame.BackStack.Clear();
                }
                else
                {
                    e.Handled = true;
                    rootFrame.GoBack();
                }
            }
