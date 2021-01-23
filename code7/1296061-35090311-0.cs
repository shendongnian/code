    public void FillRichTextField(AcroFields pdfForm, PdfStamper pdfStamper, string fieldName, string value)
    {
        System.Collections.Generic.IList<AcroFields.FieldPosition> pos = pdfForm.GetFieldPositions(fieldName);
        PdfContentByte contentByte = pdfStamper.GetOverContent(pos[0].page);
        Rectangle fieldRectangle = pos[0].position;
        PdfTemplate template = contentByte.CreateTemplate(fieldRectangle.Width, fieldRectangle.Height);
        ColumnText ct = new ColumnText(template);
        XMLWorkerHelper.GetInstance().ParseXHtml(new ColumnTextElementHandler(ct), new StringReader(value));
        for (float factor = 1; ; factor *= 1.5f)
        {
            ct.SetSimpleColumn(0, 0, factor * fieldRectangle.Width, factor * fieldRectangle.Height);
            if (!ColumnText.HasMoreText(ct.Go(false)))
            {
                ct.Go();
                template.Width = factor * fieldRectangle.Width;
                template.Height = factor * fieldRectangle.Height;
                contentByte.AddTemplate(template, 1 / factor, 0, 0, 1 / factor, fieldRectangle.Left, fieldRectangle.Bottom);
                pdfForm.RemoveField(fieldName);
                contentByte.Rectangle(fieldRectangle.Left, fieldRectangle.Bottom, fieldRectangle.Width, fieldRectangle.Height);
                contentByte.Stroke();
                return;
            }
        }
    }
