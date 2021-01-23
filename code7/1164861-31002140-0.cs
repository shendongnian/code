       private bool HaveValidAccounts(ViewModel instance,   bool DirectDebit)
        {
            if (!DirectDebit)
            { return true; }
            bool CCCResult = IsValidCCC(instance.CCC);
            bool IBANResult = IsValidIBAN(instance.IBAN);
            return CCCResult || IBANResult;
        }
         private bool IsValidIBAN(string iban)
        {
            return CommonInfrastructure.Finantial.IBAN.CheckIban(iban, false).Validation == IBAN.ValidationResult.IsValid;
        }
