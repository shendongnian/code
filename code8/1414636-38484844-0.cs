    private void TextBox_TextChanged(object sender, EventArgs e)
            {
                var searchText = SearchTextBox.Text;
                
                if (searchText != null || searchText != "")
                {
                    var FlowReader1 = (FlowDocumentReader)diffResults.Children[0];
                    var FlowReader2 = (FlowDocumentReader)oldResults.Children[0];
    
                    DoSearch(FlowReader1, searchText);
                    DoSearch(FlowReader2, searchText);
                }
            }
    
            private void DoSearch(FlowDocumentReader reader, string search)
            {
                bool toScroll = true;
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
                    if (indx >= 0)
                    {   
                        var sta = text.GetPositionAtOffset(indx);
                        var end = text.GetPositionAtOffset(indx + search.Length);
                        if (end == null)
                        {
                            end = text.GetPositionAtOffset(indx + 1);
                        }
                        var textR = new TextRange(sta, end);
                        
                        if (toScroll && text.Paragraph != null)
                        {
                            text.Paragraph.BringIntoView();
                            toScroll = false;
                        }
                        // Make it yellow
                        textR.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                    }
                    text = next;
                }
