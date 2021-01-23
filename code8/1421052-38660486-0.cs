    private void MainForm_Load(object sender, EventArgs e) {
        this.PhonesSource.DataSource = DataContext.GetPhones();
        this.CountriesSource.DataSource = DataContext.GetCountries();
        this.CitiesSource.DataSource = DataContext.GetAllCities();
    }
    private void GridView_ShownEditor(object sender, EventArgs e) {
        ColumnView view = (ColumnView)sender;
        if (view.FocusedColumn.FieldName == "CityCode") {
            LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
            string countryCode = Convert.ToString(view.GetFocusedRowCellValue("CountryCode"));
            editor.Properties.DataSource = DataContext.GetCitiesByCountryCode(countryCode);
        }
    }
    // In certain scenarios you may want to clear the secondary editor's value
    // You can use the RepositoryItem.EditValueChanged event for this purpose
    private void CountryEditor_EditValueChanged(object sender, EventArgs e) {
        this.GridView.PostEditor();
        this.GridView.SetFocusedRowCellValue("CityCode", null);
    }
        private void MainForm_Load(object sender, EventArgs e) {
            this.PhonesSource.DataSource = DataContext.GetPhones();
            this.CountriesSource.DataSource = DataContext.GetCountries();
            this.CitiesSource.DataSource = DataContext.GetAllCities();
        }
        private void GridView_ShownEditor(object sender, EventArgs e) {
            ColumnView view = (ColumnView)sender;
            if (view.FocusedColumn.FieldName == "CityCode") {
                LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                string countryCode = Convert.ToString(view.GetFocusedRowCellValue("CountryCode"));
                editor.Properties.DataSource = DataContext.GetCitiesByCountryCode(countryCode);
            }
        }
