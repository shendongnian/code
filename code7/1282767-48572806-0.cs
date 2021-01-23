    System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            System.Drawing.Printing.PrinterSettings printer = new System.Drawing.Printing.PrinterSettings();
            System.Printing.LocalPrintServer localPrintServer = new System.Printing.LocalPrintServer();
            System.Printing.PrintTicket pt = new System.Printing.PrintTicket();
            System.Printing.PrintQueue pq = new System.Printing.PrintQueue(localPrintServer, printer.PrinterName, System.Printing.PrintSystemDesiredAccess.AdministratePrinter);
            System.Printing.PageMediaSize PMS = new System.Printing.PageMediaSize(canvas.ActualWidth + 20, canvas.ActualHeight + 20);
            System.Windows.Size pageSize = new System.Windows.Size(canvas.ActualWidth+20, canvas.ActualHeight+20);
            canvas.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));
            canvas.Measure(pageSize);
            pt.PageMediaSize = PMS;
            pt.PageMediaType = System.Printing.PageMediaType.Unknown;
            pq.DefaultPrintTicket.PageMediaSize = PMS;
            pq.DefaultPrintTicket.PageMediaType = System.Printing.PageMediaType.Unknown;
            printDialog.PrintQueue = pq;
            printDialog.PrintTicket = pt;
            printDialog.PrintQueue.Commit();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(canvas, "Test");
            }
