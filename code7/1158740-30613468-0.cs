    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim doj As Date = New Date(2000, 2, 14)
        Dim dor As Date = New Date(2013, 8, 8)
        MessageBox.Show(GetDateSpanText(doj, dor))
    End Sub
    Public Shared Function GetDateSpanText(fromDate As DateTime, Optional toDate As DateTime = Nothing) As String
        Try
            Dim years As Integer = 0, months As Integer = 0, days As Integer = 0
            If toDate = Nothing Then toDate = DateTime.Now
            Do Until toDate.AddYears(-1) < fromDate
                years += 1
                toDate = toDate.AddYears(-1)
            Loop
            Do Until toDate.AddMonths(-1) < fromDate
                months += 1
                toDate = toDate.AddMonths(-1)
            Loop
            Do Until toDate.AddDays(-1) < fromDate
                days += 1
                toDate = toDate.AddDays(-1)
            Loop
            Return String.Format("{0} Years {1} Months {2} Days", years, months, days)
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
