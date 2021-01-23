    doc1.Read(originalPDF);
 
    // Specify size of output page.  (This example scales the page, maintaining the aspect ratio,
    // but you could set the MediaBox Height and Width to any desired value.)
    doc2.MediaBox.Height = doc1.MediaBox.Height / 8;
    doc2.MediaBox.Width = doc1.MediaBox.Width / 8;
    doc2.Rect.SetRect(doc2.MediaBox);
    doc2.Page = doc2.AddPage();
 
    // Create the output image
    doc2.AddImageDoc(doc1, 1, null);
    doc2.Rendering.Save(savePath);
