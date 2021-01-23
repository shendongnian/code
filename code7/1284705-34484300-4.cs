    class RichTextBoxEx : RichTextBox
    {
        DispatcherTimer timer;
        bool textChanged = false;
    
        public RichTextBoxEx()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
    
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var range = new TextRange(Document.ContentStart, Document.ContentEnd);
                range.ApplyPropertyValue(FrameworkElement.LanguageProperty, Document.Language);
            }
            finally
            {
                textChanged = false;
            }
        }
    
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            // TODO: remove if timer version works correctly
            //var changeList = e.Changes.ToList();
            //if (changeList.Count > 0)
            //{
            //    foreach (var change in changeList)
            //    {
            //        TextPointer start = null;
            //        TextPointer end = null;
            //        if (change.AddedLength > 0)
            //        {
            //            start = this.Document.ContentStart.GetPositionAtOffset(change.Offset);
            //            end = this.Document.ContentStart.GetPositionAtOffset(change.Offset + change.AddedLength);
            //        }
            //        else
            //        {
            //            int startOffset = Math.Max(change.Offset - change.RemovedLength, 0);
            //            start = this.Document.ContentStart.GetPositionAtOffset(startOffset);
            //            end = this.Document.ContentStart.GetPositionAtOffset(change.Offset);
            //        }
    
            //        if (start != null && end != null)
            //        {
            //            var range = new TextRange(start, end);
            //            range.ApplyPropertyValue(FrameworkElement.LanguageProperty, Document.Language);
            //        }
            //    }
            //}
            textChanged = true;
            base.OnTextChanged(e);
        }
    }
