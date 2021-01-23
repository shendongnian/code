    if(somecondition)
     PXStringListAttribute.SetList<DAC.Field>(sender, row,
                        new string[] { "WRJT", "WEXE", "WCMP" },
                        new string[] { "WRJT", "WEXE", "WCMP" });
    else
     PXStringListAttribute.SetList<DAC.Field>(sender, row,
                        new string[] { "WEXE", "WRJT" },
                        new string[] { "WEXE", "WRJT" });
