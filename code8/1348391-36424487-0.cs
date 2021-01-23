    Sub testccstart()
        Dim cc As ContentControl
        Set cc = ActiveDocument.ContentControls.Add(wdContentControlRichText)
        MsgBox cc.Range.Start
        ActiveDocument.Range(0).InsertBefore "Blablabla"
        MsgBox cc.Range.Start
    End Sub
