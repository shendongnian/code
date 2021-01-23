    var licValue = new List<int> { ... };
    var years = new List<int> { ... }; // 32 years listed
    int lic = 0;
    ...
    if (licValue.Any(y => !years.Contains(y))) return LicenseInfos.BADCDKEYCHAR;
    for (i = 15; i >= 4; i--)
    {
        // lic <<= 5 then license |= index of year array 
        lic *= 32 + years.IndexOf(years.Where(y => licValue[i] == y).First());
    }
    // convert int to BitArray
    var licenseArray = new BitArray(lic.PadLeft(80, '0')
        .ToCharArray().Select(b => b == '1' ? true : false).ToArray());
