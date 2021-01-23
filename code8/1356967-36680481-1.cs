    object oMissing = System.Reflection.Missing.Value;
    object oFalse = false;
    object oTrue = true;
    Word.Section sec = Globals.ThisAddIn.Application.Selection.Sections[1];
    Word.HeaderFooter ft = sec.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
    Word.Range rngFooter = ft.Range;
    object oRange = rngFooter;
    Word.Shape LogoCustom = ft.Shapes.AddPicture(logoPath, ref oFalse, ref oTrue, 
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, 
                            ref oRange);
    
