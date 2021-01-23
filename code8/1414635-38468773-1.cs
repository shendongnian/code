    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                var searchText = SearchTextBox.Text;
    
                DoSearch(FlowReader1, searchText);
                DoSearch(FlowReader2, searchText);
            }
    
            private void DoSearch(FlowDocumentReader reader, string search)
            {
                var doc = reader.Document;
                var text = doc.ContentStart;
    
                var docRange = new TextRange(doc.ContentStart, doc.ContentEnd);
                docRange.ClearAllProperties();
    
                while (true)
                {
                    var next = text.GetNextContextPosition(LogicalDirection.Forward);
                    if (next == null)
                    {
                        break;
                    }
    
                    var txt = new TextRange(text, next);
    
                    int indx = txt.Text.IndexOf(search);
                    if (indx > 0)
                    {
                        var sta = text.GetPositionAtOffset(indx);
                        var end = text.GetPositionAtOffset(indx + search.Length);
                        var textR = new TextRange(sta, end);
    
                        // Make it yellow
                        textR.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                    }
                    text = next;
                }
    
            }
