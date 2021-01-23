    IQueryable<CashierBalance> icashierBalance = _cashierDataManagement.GetIQueryableCashierBalance();
            var currencies = icashierBalance
                             .AsEnumerable()
                             .Select(a => new
            {
                Id = a.Currency.Id,
                Name = a.Currency.Name,
                Simbol = a.Currency.Symbol,
                ShorName = a.Currency.ShortName,
                RoundingUp = a.Currency.RoundingUp,
                RoundingDown = a.Currency.RoundingDown,
                DenominationMin = a.Currency.DenominationMin,
                Denominations = cashierdata.useDenominations ? (Denomination) a.Currency.Denominations.Select(q => q )
    
                 : (Denomination) null
    
    
            });
