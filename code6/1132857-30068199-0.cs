            var page = doc.Pages[pagn];
            string pdfAnnotationMsg = "Test Annotation 123";
            PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(new RectangleF((float)x, (pageHeight * 1.325f) - (float)y - VertOff2, 5, 5), pdfAnnotationMsg);
            popupAnnotation.Border.Width = 1;
            popupAnnotation.Open = false;
            popupAnnotation.Border.HorizontalRadius = 1;
            popupAnnotation.Border.VerticalRadius = 1;
            popupAnnotation.Icon = PdfPopupIcon.Comment;
            page.Annotations.Add(popupAnnotation);
            
            //Save the PDF document
            MemoryStream ms=new MemoryStream();
            doc.Save(ms);
            doc.Close(true);
            //Load the PDF document again
            doc = new PdfLoadedDocument(ms);
            PdfLoadedAnnotationCollection annotationCollection = doc.Pages[0].Annotations;
            var text = annotationCollection[0].Text;
