    var result = from co in context.CachierOperations
                 where co.ActivationStart < SqlFunctions.GetDate() &&
                       co.ActivationEnd > SqlFunctions.GetDate() &&
                       co.LastUsed.AddMinutes(8) < SqlFunctions.GetDate() &&
                       co.SkiPassNumber.Contains("DA3C12DC2186018220")
                 select co.Id;
