    var flags = (Webcc1.Contains(licensePartID)) ? 1 : 0;
    flags |= (Webcc3.Contains(licensePartID)) ? 2 : 0;
    flags |= (Webcc5.Contains(licensePartID)) ? 4 : 0;
    switch(flags)
    {
        case 1:
            dtExpiryDate = dtActivatedDate.AddYears(1);
            int isExpiry = DateTime.Compare(dtActivatedDate, dtExpiryDate);
            if (isExpiry >= 0)
            {
                setError(lblSystemErr, "This action cannot be performed. The subscription period of the license key has expired");
                return;
            }
            break;
        case 2:
            dtExpiryDate = dtActivatedDate.AddYears(3);
            int isExpiry = DateTime.Compare(dtActivatedDate, dtExpiryDate);
            if (isExpiry >= 0)
            {
                setError(lblSystemErr, "This action cannot be performed. The subscription period of the license key has expired");
                return;
            }
            break;
        case 4:
            dtExpiryDate = dtActivatedDate.AddYears(5);
            int isExpiry = DateTime.Compare(dtActivatedDate, dtExpiryDate);
            if (isExpiry >= 0)
            {
                setError(lblSystemErr, "This action cannot be performed. The subscription period of the license key has expired");
                return;
            }
            break;
    }
    }
