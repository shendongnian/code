    class RichTextBoxEx : RichTextBox
    {
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            var changeList = e.Changes.ToList();
            if (changeList.Count > 0)
            {
                foreach (var change in changeList)
                {
                    TextPointer start = null;
                    TextPointer end = null;
                    if (change.AddedLength > 0)
                    {
                        start = this.Document.ContentStart.GetPositionAtOffset(change.Offset);
                        end = this.Document.ContentStart.GetPositionAtOffset(change.Offset + change.AddedLength);
                    }
                    else
                    {
                        int startOffset = Math.Max(change.Offset - change.RemovedLength, 0);
                        start = this.Document.ContentStart.GetPositionAtOffset(startOffset);
                        end = this.Document.ContentStart.GetPositionAtOffset(change.Offset);
                    }
    
                    if (start != null && end != null)
                    {
                        var range = new TextRange(start, end);
                        range.ApplyPropertyValue(FrameworkElement.LanguageProperty, Document.Language);
                    }
                }
            }
            base.OnTextChanged(e);
        }
    }
