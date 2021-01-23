    string myFileName = "A.docx";
    if (myItem is DocumentItem)
    {
       var docItem = myItem as DocumentItem;
       for (var i = 1; i <= docItem.Attachments.Count; i++)
       {
          var attachment = docItem.Attachments[i];
          attachment.SafeAsFile(myFileName);
       }
    }
