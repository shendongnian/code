    printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
                printDialog.PrintTicket.PageBorderless = PageBorderless.None;
                var printingCapabilities = printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket);
                if (printingCapabilities.PageImageableArea == null)
                {
                    return;
                }
                var document = new FixedDocument();
                document.DocumentPaginator.PageSize = new Size(printingCapabilities.PageImageableArea.ExtentWidth, printingCapabilities.PageImageableArea.ExtentHeight);
                foreach (var imageStream in imageStreams)
                {
                    document.Pages.Add(GeneratePageContent(imageStream, printingCapabilities, printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight));
                }
                try
                {
                    printDialog.PrintDocument(document.DocumentPaginator, GlobalConstants.SoftwareName);
                }
    private PageContent GeneratePageContent(Stream imageStream, PrintCapabilities printingCapabilities, double paperWidth, double paperHeight)
        {
            imageStream.Seek(0, SeekOrigin.Begin);
            
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = imageStream;
            bmp.EndInit();
            var margin = new Thickness();
            var pageSize = new Size();
            if (printingCapabilities.PageImageableArea != null)
            {
                margin = new Thickness(
                    printingCapabilities.PageImageableArea.OriginWidth,
                    printingCapabilities.PageImageableArea.OriginHeight,
                    printingCapabilities.PageImageableArea.OriginWidth,
                    printingCapabilities.PageImageableArea.OriginHeight);
                pageSize = new Size(printingCapabilities.PageImageableArea.ExtentWidth, printingCapabilities.PageImageableArea.ExtentHeight);
            }
            
            var imageUiElement = new Image
            {
                Source = bmp,
                Margin = margin
            };
            var canvas = new Grid { Width = paperWidth, Height = paperHeight };
            canvas.Children.Add(imageUiElement);
            var fixedPage = new FixedPage
            {
                Width = paperWidth,
                Height = paperHeight
            };
            fixedPage.Children.Add(canvas);
            var pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(fixedPage);
            pageContent.Measure(pageSize);
            pageContent.Arrange(new Rect(new Point(), pageSize));
            pageContent.UpdateLayout();
            return pageContent;
        }
