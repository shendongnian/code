    private void addTitle_Click(object sender, RibbonControlEventArgs e)
            {
                AddRichTextControlAtSelection();
            }
    
    
            int count = 0;
            private void AddRichTextControlAtSelection()
            {
                word.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;
    
                Document extendedDocument = Globals.Factory.GetVstoObject(currentDocument);
    
                if (currentDocument.ContentControls.Count > 0)
                {
    
                    currentDocument.ActiveWindow.Selection.Range.HighlightColorIndex = word.WdColorIndex.wdYellow;
                    currentDocument.ActiveWindow.Selection.Range.Select();
    
                    richTextControls = new List<RichTextContentControl>(); 
                    
                    foreach (word.ContentControl nativeControl in currentDocument.ContentControls)
                    {
                        if (nativeControl.Type == Microsoft.Office.Interop.Word.WdContentControlType.wdContentControlRichText) 
                        {
                            count++;
                            RichTextContentControl tempControl = extendedDocument.Controls.AddRichTextContentControl("VSTORichTextControl" + count.ToString());
                            richTextControls.Add(tempControl);
                            tempControl.Title = "Title";
                            tempControl.Tag = "title";
                            
                            break;
                         }
                    }
                }
    
                else
                {
                    RichTextContentControl VSTORichTextControl;
                    VSTORichTextControl = extendedDocument.Controls.AddRichTextContentControl("VSTORichTextControl");
                    VSTORichTextControl.PlaceholderText = "Enter the DM title";
                    VSTORichTextControl.Title = "Title";
                    VSTORichTextControl.Tag = "title";
                }
        
            }
