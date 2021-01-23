    using System.Globalization;
    using System.Threading;
    
    
    private void SetCultureToUSEnglish()
    {
    	CultureInfo englishUSCulture = new CultureInfo("en-US");
    	CultureInfo.DefaultThreadCurrentCulture = englishUSCulture;
    }
