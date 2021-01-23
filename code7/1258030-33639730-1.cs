    public void InputNameZipClickNext()
    {
        txtClientName.Click();
        txtClientName.SendKeys(bogusCompanyName);
        txtZipCode.Click();
        txtZipCode.SendKeys(getZip(_state));
        txtInsuredName.Clear();
        txtInsuredName.SendKeys(clientCompanyName);
        txtAddressPhysical.Clear();
        txtAddressPhysical.SendKeys(clientAddress);
        txtCityPhysical.Clear();
        txtCityPhysical.SendKeys(getCity(_state));
        txtStatePhysical.SendKeys(_state);
        btnCopyPhysical.Click();
        btnCreateNext.Click();
    }
