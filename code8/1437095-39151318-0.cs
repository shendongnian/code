      var duh = _app2Lead.DataAccess.App2BonusPromos.FindByExp(
                    x =>
                        x.ApplicationBeginDate < policyApplicationDate && x.ApplicationEndDate > policyApplicationDate &&
                        x.EffectiveDate == policyEffectiveDate).Any();
    
                if (duh)
                {
                    return true;
                }
                return false;
