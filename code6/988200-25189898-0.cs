     private void ReDrawAttachmentsGrid()
        {
            foreach (var child in AttachmentsPanel.Children)
            {
                if (child is PdfAttachment)
                {
                    var childAsPdfAttachment = child as PdfAttachment;
                    var indexOfAttachment = PdfAttachments.IndexOf(childAsPdfAttachment);
                    var tilesPerRow = (int)Math.Floor(AttachmentsOuterGrid.ActualWidth / 112);
                    var desiredRowIndex = (int)(indexOfAttachment / tilesPerRow);
                    desiredRowIndex += desiredRowIndex;
                    var desiredColumnIndex = (int)(indexOfAttachment % tilesPerRow);
                    if (AttachmentsPanel.RowDefinitions.Count - 1 < desiredRowIndex)
                    {
                        while (AttachmentsPanel.RowDefinitions.Count - 1 < desiredRowIndex)
                            AttachmentsPanel.RowDefinitions.Add(new RowDefinition());
                    }
                    if (AttachmentsPanel.ColumnDefinitions.Count - 1 < desiredColumnIndex)
                    {
                        var column = new ColumnDefinition();
                        column.Width = new GridLength(112);
                        AttachmentsPanel.ColumnDefinitions.Add(column);
                    }
                    Grid.SetColumn(childAsPdfAttachment, desiredColumnIndex);
                    Grid.SetRow(childAsPdfAttachment, desiredRowIndex);
                }
            }
