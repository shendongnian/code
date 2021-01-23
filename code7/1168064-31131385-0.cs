     private void LoadServices()
        {
            txtServiceName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtServiceName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtServiceName.AutoCompleteCustomSource = colValues;
        }
