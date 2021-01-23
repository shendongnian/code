    if (SName != null & sName.Length >0)
    {
        for (int i = 0; i < SName.Length; i++)
        {
            Response.Write(SName[i]);
            Response.Write(Email[i]);
        }
    }
