    wordDocument.Bookmarks[bookmarkName].Range.Select();
    Selection sel = wordApplication.Selection;
                
    wf.RichTextBox tb = new wf.RichTextBox();
    tb.Rtf = rtfText;
    string fileName = Path.Combine(UserInfo.User.TempPath,
                                                       Guid.NewGuid() + ".rtf");
    tb.SaveFile(fileName, wf.RichTextBoxStreamType.RichText);
    object ConfirmConversions = false;
    object Link = false;
    object Attachment = false;
    object lMissing = System.Reflection.Missing.Value;
    sel.InsertFile(fileName, ref lMissing, ref ConfirmConversions, ref Link, ref Attachment);
    File.Delete(fileName);
