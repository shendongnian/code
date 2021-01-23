    var WApplication:twordapplication; rg,rngTab:range;
    commentText:olevariant;
    begin
    commentText:='123';
    WApplication := twordapplication.Create(form1);
    WApplication.Connect;
    WApplication.Visible:=true;
    WApplication.Activate;
    rg:= WApplication.Selection.Range; // get the range of the current selection (all document)
    rngTab:= rg;
         //set the coordinate of the Range of the text
         rngTab.Start:= 1;
         rngTab.End_:= 2;
         rg.Select();
         WApplication.ActiveDocument.Comments.Add(rngTab, commentText);// add comment to text
         rngtab:=WApplication.ActiveDocument.Tables.Item(1).cell(2,2).range;
         rngtab.Select();
         WApplication.ActiveDocument.Comments.Add(rngTab, commentText); // add comment to cell in the table
    end;
