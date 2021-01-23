    if (SName != null && SName.Length > 0 && Email != null && Email.Length > 0)
    {
         for (int i = 0,j=0; i < SName.Length && j<Email.Length; i++,j++)
         {
              Response.Write(SName[i]);
              Response.Write(Email[j]);
         }
    }
