    class CompaniesViewController
    {
        public event Action<Company> CompanySelected;
    
        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
            //Raise CompanySelected event if it isn't null and pass selected company.
        }
    }
