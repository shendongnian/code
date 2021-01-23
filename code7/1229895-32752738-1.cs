     public void overallTextReplace(RichTextBox[] rtb) 
    {
         string[] keyword = { "FCI", "CNG", "DCR", "EZR", "VASC", "CND" };
         string[] newString = { "Forecourt Controller","Case Number Declined" ,"Case Number Given", "Dispenser Card reader", "Enhanced Zone Router", "Verifone Authorized Service Contractor" };
         for (int i = 0; i < rtb.Length; i++) 
         {
             for (int j = 0; j < 6; j++) 
            {
                 rtb[i].Rtf=rtb[i].Rtf.Replace(keyword[j],newString[j]);
            }
         }
    }
    
