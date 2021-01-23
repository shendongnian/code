    if (counterParty == null)
    {
        mailAddressesOfCounterparty = new List<Email>();
        Email unKnownEmail = new Email();
        unKnownEmail.EmailAddress = loopPayment.ShortNameCalypso + "@NotInCounterpartyTable.nl";
        mailAddressesOfCounterparty.Add(unKnownEmail);
    }
    else
    {
        mailAddressesOfCounterparty = emailAddress.Where(ea => ea.CounterPartyId == counterParty.Id && ea.IsOptionContract == startOfGroupPayment.OptionContract).ToList();
        if (!mailAddressesOfCounterparty.Any()) 
        {
            Email unKnownEmail = new Email();
            unKnownEmail.EmailAddress = loopPayment.ShortNameCalypso + "@NotInCounterpartyTable.nl";
            mailAddressesOfCounterparty.Add(unKnownEmail);
        }
    }
