    public class AgentSalesDetailListViewAdapter
    {
        private List<AgentSalesDetailsList> _details;
        private ListView                    _view;
        private ISet<string>                _productNames = new SortedSet<string>();
        private DataTable                   _data         = new DataTable();
        public AgentSalesDetailListViewAdapter(List<AgentSalesDetailsList> details, ListView view)
        {
            _details = details;
            _view    = view;
        }
        public void SetUpView()
        {
            PopulateProductNames();
            PrepareDataColumns();
            FillData();
            FillView();
        }
        private void PopulateProductNames()
        {
            _productNames.Clear();
            // collect all product names into a single set
            foreach ( AgentSalesDetailsList detail in _details )
            {
                foreach ( SalesProducts product in detail.Products )
                {
                    _productNames.Add(product.ProductName);
                }
            }
        }
        private void PrepareDataColumns()
        {
            _data.Columns.Clear();
            _view.Columns.Clear();
            // add columns for the needed data to the DataTable
            _data.Columns.Add("firstname");
            _data.Columns.Add("lastname");
            _data.Columns.Add("phone");
            // add a column fo every product in your details list
            foreach ( string productName in _productNames )
            {
                _data.Columns.Add(productName);
            }
            _data.Columns.Add("TotalPrice");
            // now add the same columns to the ListView
            foreach ( DataColumn column in _data.Columns )
            {
                _view.Columns.Add(column.ColumnName);
            }
        }
        private void FillData()
        {
            // fill data table with data from your list
            foreach ( AgentSalesDetailsList detail in _details )
            {
                DataRow row = _data.NewRow();
                row["firstname"] = detail.firstname;
                row["lastname"] = detail.lastname;
                row["phone"] = detail.phone;
                row["TotalPrice"] = detail.TotalPrice;
                // init product columns with -
                foreach ( string productName in _productNames )
                {
                    row[productName] = "-";
                }
                // set the product columns
                foreach ( SalesProducts product in detail.Products )
                {
                    row[product.ProductName] = product.amount;
                }
                _data.Rows.Add(row);
            }
        }
        private void FillView()
        {
            // copy data from table to view
            foreach ( DataRow row in _data.Rows )
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for ( int i = 1; i < _data.Columns.Count; i++ )
                {
                    item.SubItems.Add(row[i].ToString());
                }
                _view.Items.Add(item);
            }
        }
    }
