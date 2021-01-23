    var items = _vm.Result.Errors;
    if (bCompanyID)
        items = items.Where(n => n.CompanyID == SelectedItem.CompanyID);
    if (bTaxCode)
        items = items.Where(n => n.TaxCode == SelectedItem.TaxCode);
    . . .
