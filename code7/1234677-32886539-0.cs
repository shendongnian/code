    _adminEntityView .CustomSort = new AdminSorter(); 
     
    public class AdminSorter: IComparer
    {
        public int Compare(object x, object y)
        {
            DB_ADMINISTRATEUR X= x as Customer;
            DB_ADMINISTRATEUR Y= y as Customer;
            return X.Name.CompareTo(Y.Name);
        }
    }
