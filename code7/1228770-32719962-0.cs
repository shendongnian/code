    items = _vm.Result_Error.AsEnumerable();
    if(bCompanyID)
        items = items.Where(n => n.CompanyID == SelectedItem.CompanyID);
    if(bTaxCode)
        items = items.Where(n => n.TaxCode == SelectedItem.TaxCode);
    if(bAccountCode)
        items = items.Where(n =>n.AccountCode == SelectedItem.AccountCode);
