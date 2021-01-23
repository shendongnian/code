            TreeNode newNode = TreeNode.New(PageType, tree);
            newNode.DocumentName = mediaFile.FileName;
            newNode.DocumentName = fileName.Trim();
            newNode.SetValue("FileDate", fileDate);
            DocumentHelper.InsertDocument(newNode, parentNode.NodeID);
            AttachmentInfo newAttachment = null;
            // Path to the file to be inserted. This example uses an explicitly defined file path. However, you can use an object of the HttpPostedFile type (uploaded via an upload control).
            string filePath = MediaLibraryPath + @"\" + mediaFile.FileName + mediaFile.FileExtension;
            // Insert the attachment and update the document with its GUID
            newAttachment = DocumentHelper.AddUnsortedAttachment(newNode, Guid.NewGuid(), filePath, tree, ImageHelper.AUTOSIZE, ImageHelper.AUTOSIZE, ImageHelper.AUTOSIZE);
            // attach the new attachment to the page/document
            newNode.SetValue("FileAttachment", newAttachment.AttachmentGUID);
            DocumentHelper.UpdateDocument(newNode);
            newNode.Publish();
