    class InvoiceDocument : PrintDocument
    {
        public InvoiceDocument(Invoice invoice)
        {
            _invoice = invoice;
            _currentSection = new MainPage(this);
        }
        private Invoice _invoice;
        public Invoice Invoice => _invoice;
        private InvoiceSection _currentSection;
        public InvoiceSection CurrentSection => _currentSection;
        #region Fonts
        private Font _titleFont = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
        public Font TitleFont => _titleFont;
        private Font _headerFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
        public Font HeaderFont => _headerFont;
        private Font _regularFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        public Font RegularFont => _regularFont;
        private Font _boldFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        public Font BoldFont => _boldFont;
        #endregion
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            _currentSection?.Render(e);
        }
        public void ChangeSection(InvoiceSection nextSection)
        {
            _currentSection = nextSection;
        }
    }
