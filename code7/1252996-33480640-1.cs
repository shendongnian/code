        public static void Print(IEnumerable<UIElement> dataForPrint, string printerName)
        {
            try
            {
                var printDialog = new PrintDialog();
                using (var printQueue = new PrintQueue(new PrintServer(), printerName))
                {
                    printDialog.PrintQueue = printQueue;
                    var area = printDialog.PrintQueue.GetPrintCapabilities();
                    if (area.PageImageableArea == null) throw new Exception("Failed to load printer settings.");
                    var flowDocument = new FlowDocument
                    {
                        PagePadding = new Thickness(area.PageImageableArea.OriginWidth, 0, 0, 0),
                        PageWidth = area.PageImageableArea.ExtentWidth + area.PageImageableArea.OriginWidth
                    };
                    foreach (var uiElement in dataForPrint)
                    {
                        flowDocument.Blocks.Add(new BlockUIContainer(uiElement));
                    }
                    var paginator = ((IDocumentPaginatorSource) flowDocument).DocumentPaginator;
                    printDialog.PrintDocument(paginator, "A Flow Document");
                }
            }
            catch (NotSupportedException)
            {
                
            }
            catch (Exception e)
            {
                Log(e);
            }
        }
