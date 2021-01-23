    Sub CountChars()
        Dim iCount(57) As Integer
        Dim x As Integer
        Dim iTotal As Integer
        Dim iAsc As Integer
    
        Application.ScreenUpdating = False
        iTotal = ActiveDocument.Range.Characters.Count
    
        For x = 1 To iTotal
            iAsc = Asc(ActiveDocument.Range.Characters(x))
            If iAsc >= 65 And iAsc <= 122 Then
            iCount(iAsc - 65) = iCount(iAsc - 65) + 1
            End If
        Next x
        For x = 0 To 57
            Debug.Print x, iCount(x)
        Next x
        Application.ScreenUpdating = True
    End Sub
