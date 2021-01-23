    if (IsThereNoEdgeOrNoSignal(ocrResult))
    {
       //no edge or no signal
    }
    else
    {
      //Not no edge or no signal
    }    
    private static bool IsThereNoEdgeOrNoSignal(string ocrResult)
    {
            if (string.IsNullOrEmpty(ocrResult))
                return false;
            return ocrResult.IndexOf("edg", StringComparison.CurrentCultureIgnoreCase) >= 0 || ocrResult.IndexOf("gna", StringComparison.CurrentCultureIgnoreCase) >= 0;
    }
