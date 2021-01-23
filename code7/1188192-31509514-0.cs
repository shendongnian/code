    public class Foo
    {
        private List<Payee> _payees;
        private ICollectionView _filteredPayees;
        public ICollectionView FilteredPayees
        {
            get { return _filteredPayees; }
        }
        public Foo()
        {
            _payees = GetPayees();
            _filteredPayees = CollectionViewSource.GetDefaultView(_payees);
            _filteredPayees.Filter = FilterPayees;
        }
        private bool FilterPayees(object item)
        {
            var payee = item as Payee;
            if (payee == null)
            {
                return false;
            }
            if (_settings.ShowInactivePayees)
            {
                return true;
            }
            return payee.IsOpen;
        }
    }
