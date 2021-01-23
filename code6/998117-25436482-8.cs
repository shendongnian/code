        private void ReloadDropDown()
        {
            dsPopulateProvider.SelectCommand = GetDropDownGuery();
            ddlProvider.DataBind();
        }
