    StringBuilder sb = new StringBuilder();
    bool first = true;
    foreach (Var Imd in Obj.Imds)
    {  
        if (i < 50000)
        {
           if (first)
           {
               first = false;
           }
           {
               sb.Append(", ");
           }
           sb.Append(Imd.ImdValue);
        }
    }
    IMDVals = sb.ToString();
