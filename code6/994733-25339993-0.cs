        bool StopLoading = false; // This is required to ensure that only the specified amount of messages will be loaded at once.
        // If we scroll upper the messages, then don't scroll. If we scroll to bottom, scroll the messages
        private void MessageScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var obj = sender as ScrollViewer;
            // The scrollbar is at the bottom
            if (obj.VerticalOffset == obj.ScrollableHeight)
            {
                // The while loop removes loaded messages when we have scrolled to the bottom
                Channel ch = (Channel)((ScrollViewer)sender).Tag;
                while (ch.TheFlowDocument.Blocks.Count > GlobalManager.MaxMessagesDisplayed)
                {
                    ch.TheFlowDocument.Blocks.Remove(ch.TheFlowDocument.Blocks.FirstBlock);
                    if (ch.MessagesLoadedFrom + 1 + GlobalManager.MaxMessagesDisplayed < GlobalManager.MaxMessagesInMemory)
                        ch.MessagesLoadedFrom++;
                }
                // The automatic scroll when the scrollbar is at the bottom
                obj.ScrollToEnd();
            }
            // The scrollbar is at the top
            else if (obj.VerticalOffset == 0) // Load older messages
            {
                if (!StopLoading)
                {
                    Channel ch = (Channel)((ScrollViewer)sender).Tag;
                    if (ch.MessagesLoadedFrom != 0)
                    {
                        int loaded = LoadMessages(ch, GlobalManager.NumOfOldMessagesToBeLoaded);
                        double plus = first.Padding.Top + first.Padding.Bottom + first.Margin.Bottom + first.Margin.Top; // Since all of my paragraphs have the same Margin and Padding I can do this
                        double sum = 0;
                        Block temp = ch.TheFlowDocument.Blocks.FirstBlock;
                        for (int i = 0; i < loaded; i++)
                        {
                            sum += temp.FontSize + plus;
                            temp = temp.NextBlock;
                            if (temp == null)
                                break;
                        }
                        obj.ScrollToVerticalOffset(sum);
                    }
                    StopLoading = true;
                }
            }
            // The scrollbar is not at the top and not at the bottom. We can enable loading older messages
            else
            {
                StopLoading = false;
            }
            e.Handled = true;
        }
