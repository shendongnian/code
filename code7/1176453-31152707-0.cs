    new GridColumn {
        Visible = true,
        FieldName = "blah",
        Name = "blah",
        FilterMode = ColumnFilterMode.DisplayText, //<= filter mode
        ColumnEdit = new RepositoryItemGridLookUpEdit{
            DisplayMember = "Name",
            ValueMember = "Id",
            DataSource = ViewModel.Components
        }
    }
