    private TextPointer _start, _end;
    
            private void Image_PointerEntered(object sender, PointerRoutedEventArgs e) {
                this._start = this.richTextBlock.SelectionStart;
                this._end = this.richTextBlock.SelectionEnd;
                this.richTextBlock.IsTextSelectionEnabled = false;
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 1);
            }
    
            private void Image_PointerExited(object sender, PointerRoutedEventArgs e) {
                this.richTextBlock.IsTextSelectionEnabled = true;
                this.richTextBlock.Select(this._start, this._end);
                Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
            }
