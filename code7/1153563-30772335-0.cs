            const char marker = ':';
            var textSections = text.Split(marker);
            var emojiRemovedText = string.Empty;
            var notMatchedCount = 0;
            textSections.ToList().ForEach(section =>
            {
                if (emojiNames.Contains(section))
                {
                    notMatchedCount = 0;
                }
                else
                {
                    if (notMatchedCount++ > 0)
                    {
                        emojiRemovedText += marker.ToString();
                    }
                    emojiRemovedText += section;
                }
            });
