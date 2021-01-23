    // Test tricky names
    Debug.WriteLine(getCountryEnum("Curaçao"));
    Debug.WriteLine(getCountryEnum("Saint Barthélemy"));
    Debug.WriteLine(getCountryEnum("Croatia/Hrvatska"));
    Debug.WriteLine(getCountryEnum("Korea, Democratic People's Republic"));
    Debug.WriteLine(getCountryEnum("US Minor Outlying Islands"));
    Debug.WriteLine(getCountryEnum("Cote d'Ivoire"));
    Debug.WriteLine(getCountryEnum("Heard and McDonald Islands"));
    // Enums that fail
    Debug.WriteLine(getCountryEnum("Congo, Democratic Republic of")); // _congoDemocraticPeoplesRepublic added to exceptions
    Debug.WriteLine(getCountryEnum("Myanmar (Burma)")); // _myanmar added to exceptions
    Debug.WriteLine(getCountryEnum("Netherlands Antilles (Deprecated)")); // Skip Deprecated
    Debug.WriteLine(getCountryEnum("Serbia and Montenegro (Deprecated)")); // Skip Deprecated
    Debug.WriteLine(getCountryEnum("Wallis and Futuna")); // _wallisAndFutunaIslands added to exceptions
