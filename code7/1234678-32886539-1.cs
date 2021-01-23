    _adminEntityView .CustomSort = new AdminSorter(); 
     
    public class AdminSorter: IComparer
    {
        public int Compare(object x, object y)
        {
            DB_ADMINISTRATEUR X = x as DB_ADMINISTRATEUR;
            DB_ADMINISTRATEUR Y = y as DB_ADMINISTRATEUR;
            return X.Name.CompareTo(Y.Name);
        }
    }
