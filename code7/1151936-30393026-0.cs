    Bitmap bmpImage = null;
    string strPdfDocSavePath = @"D:\Images\";
    bmpImage = PctrBx.Image;
    string strImageName = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
    bmpImage.Save(strPdfDocSavePath + @"\" + strImageName + ".bmp");
    
    MigraDoc.DocumentObjectModel.Shapes.Image img = row.Cells[0].AddImage(strPdfDocSavePath + @"\" + strImageName + ".bmp"); // Here i am using table for displaying image , add column and row to table, add image to desired cell
    row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
    img.LockAspectRatio = true;
    img.WrapFormat.Style =MigraDoc.DocumentObjectModel.Shapes.WrapStyle.Through;
    img.Width = "7cm";
