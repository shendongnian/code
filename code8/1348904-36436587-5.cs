    abstract class InvoiceSection
    {
        protected InvoiceSection(InvoiceDocument invoiceDocument)
        {
            this.InvoiceDocument = invoiceDocument;
        }
        public InvoiceDocument InvoiceDocument { get; }
        public abstract void Render(PrintPageEventArgs e);
        public Invoice Invoice => InvoiceDocument?.Invoice;
    }
    internal class MainPage : InvoiceSection
    {
        public MainPage(InvoiceDocument invoiceDocument) : base(invoiceDocument) { }
        public override void Render(PrintPageEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Green, e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Left + 100, e.MarginBounds.Top + 100);
            e.Graphics.DrawString(Invoice.CompanyName, InvoiceDocument.TitleFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + 30);
            e.HasMorePages = true;
            InvoiceDocument.ChangeSection(new SummmarySection(InvoiceDocument));
        }
    }
    internal class SummmarySection : InvoiceSection
    {
        public SummmarySection(InvoiceDocument invoiceDocument) : base(invoiceDocument)
        {
        }
        public override void Render(PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, 20);
            e.Graphics.DrawString("Payments", InvoiceDocument.HeaderFont, Brushes.Black, e.MarginBounds.Left + 200, e.MarginBounds.Top + 2);
            int y = e.MarginBounds.Top + 25;
            while (_currentPaymentIndex < Invoice.Payments.Count && y < e.MarginBounds.Bottom)
            {
                Payment payment = Invoice.Payments[_currentPaymentIndex];
                e.Graphics.DrawString(payment.Description, InvoiceDocument.RegularFont, Brushes.Black, e.MarginBounds.Left + 150, y);
                e.Graphics.DrawString($"{payment.Amount:C}", InvoiceDocument.RegularFont, Brushes.Black, e.MarginBounds.Right - 150, y);
                y = y + InvoiceDocument.RegularFont.Height;
                _currentPaymentIndex++;
            }
            if (_currentPaymentIndex < Invoice.Payments.Count)
            {
                e.HasMorePages = true;
            }
        }
        private int _currentPaymentIndex = 0;
    }
