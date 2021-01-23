        //Returns the changed field code
        private string GenerateNestedField(Word.Field fldOuter, 
                             string sPlaceholder)
        {
            Word.Range rngFld = fldOuter.Code;
            Word.Document doc = (Word.Document) fldOuter.Parent;
            bool bFound;
            string sFieldCode;
    
            //Get the field code from the placeholder by removing the { }
            sFieldCode = sPlaceholder.Substring(1, sPlaceholder.Length - 2); //Mid(sPlaceholder, 2, Len(sPlaceholder) - 2)
            rngFld.TextRetrievalMode.IncludeFieldCodes = true;
            bFound = rngFld.Find.Execute(sPlaceholder);
            if (bFound) doc.Fields.Add(rngFld, Word.WdFieldType.wdFieldEmpty, sFieldCode, false);
            return fldOuter.Code.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getWordInstance(); //Object defined as a class member for Word.Application
            Word.Document doc = wdApp.ActiveDocument;
            Word.View vw = doc.ActiveWindow.View;
            Word.Range rngTarget = null;
            Word.Field fldIf = null;
            string sIfField, sFieldCode;
            string sQ = '"'.ToString();
            bool bViewFldCodes = false;
    
            sIfField = "IF {Page} = {NumPages} " + sQ + "Last" + sQ + " " + sQ + "Other" + sQ;
    
            rngTarget = doc.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            bViewFldCodes = vw.ShowFieldCodes;
            //Finding text in a field codes requires field codes to be shown
            if(!bViewFldCodes) vw.ShowFieldCodes = true;
            //Create the nested field: { IF {Pages} = {NumPages} "Last" "Other" }
            fldIf = doc.Fields.Add(rngTarget, Word.WdFieldType.wdFieldEmpty, sIfField, false);
            sFieldCode = GenerateNestedField(fldIf, "{Page}");
            sFieldCode = GenerateNestedField(fldIf, "{NumPages}");
            rngTarget.Fields.Update();
            vw.ShowFieldCodes = bViewFldCodes;
        }
