    const int NumRows = 58;
    const int NumCols = 13;
    object objMiss = System.Reflection.Missing.Value;
    objTab1 = objDoc.Tables.Add(objWordRng, NumRows, NumCols,
                            ref objMiss, ref objMiss); //add table object in word document
    objTab1.Range.ParagraphFormat.SpaceAfter = 6;
    int iRow, iCols;
    string strText;
    
    for (iRow = 1; iRow <= NumRows; iRow++)
        for (iCols = 1; iCols <= NumCols; iCols++)
           {
               strText = "row:" + iRow + "col:" + iCols;
               objTab1.Cell(iRow, iCols).Range.Text = strText; //add some text to cell
           }
