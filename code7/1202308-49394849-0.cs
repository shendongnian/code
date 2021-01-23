        Dim enAU As CultureInfo = CultureInfo.CreateSpecificCulture("en-AU")
        Dim SaveOptions As New CsvSaveOptions(CsvType.CommaDelimited)
        With SaveOptions
            .FormatProvider = enAU
        End With
        For Each row In ws.Rows
            For Each cell In row.AllocatedCells
                If Not (String.IsNullOrEmpty(cell.Value)) Then
                    cell.Value = cell.GetFormattedValue()
                End If
            Next
        Next
        ws.Save(sSaveAsFullFilename, New CsvSaveOptions(CsvType.CommaDelimited) With {.FormatProvider = enAU}) 
