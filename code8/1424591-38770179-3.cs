    public void BindSuppliers()
        {
            using (ScanFlowDataClassesDataContext db = new ScanFlowDataClassesDataContext(GlobalConfig.connectionString))
        {
            var suppliers = from s in db.Suppliers
                select new Tuple<int,string>(s.Id, s.Name);
            cmbSuppliers.DisplayMemberPath = "Item2";
            cmbSuppliers.SelectedValuePath = "Item1";
            cmbSuppliers.ItemsSource = suppliers.OrderBy(s => s.Item2);
        }
    }
