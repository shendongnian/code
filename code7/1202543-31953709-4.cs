    // In a new file, so your changes don't get overwritten:
    public partial class Customer
    {
        public string CorrectName
        {
            get { return Name.Replace('¤', 'Ñ').Replace('¥', 'ñ'); }
            set { Name = value.Replace('Ñ', '¤').Replace('ñ', '¥'); }
        }
    }
