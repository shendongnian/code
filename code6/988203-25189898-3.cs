     var pdfViewer = new PdfViewer(e.Images, e.ByteArray, e.DisplayName, e.AttachmentKey);
                pdfViewer.AttachmentClosed += pdfViewer_AttachmentClosed;
                AttachmentsPanel.Children.Add(pdfViewer);
                Grid.SetColumnSpan(pdfViewer, 100);
                var desiredRowIndex = Grid.GetRow(senderAsPdfAttachment) + 1;
                if (AttachmentsPanel.RowDefinitions.Count - 1 < desiredRowIndex)
                {
                    while (AttachmentsPanel.RowDefinitions.Count - 1 < desiredRowIndex)
                        AttachmentsPanel.RowDefinitions.Add(new RowDefinition());
                }
                Grid.SetRow(pdfViewer, desiredRowIndex);
