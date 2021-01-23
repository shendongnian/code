    Private Sub UpdateBoldedDatesWT()
        mcCalendar.UpdateBoldedDates()
    End Sub
    Public Sub LoadBoldedDates()
        Dim bDates As List(Of Date)
        Try
            Dim dExt As New DatesHelper(sqlConn)
            bDates = dExt.GetAppointmentDates(mcCalendar.SelectionStart)
            mcCalendar.RemoveAllBoldedDates()
            For Each d As Date In bDates
                mcCalendar.AddBoldedDate(d)
            Next
            mcCalendar.BeginInvoke(New MethodInvoker(AddressOf UpdateBoldedDatesWT))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error loading bolded dates")
        End Try
    End Sub
