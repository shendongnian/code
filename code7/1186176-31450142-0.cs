    Private Sub PrintTable()
            Dim ft As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED)
            Dim mf As New iTextSharp.text.Font(ft, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)
            Dim doc As Document = New Document(PageSize.A4, 70, 30, 40, 40)
            Dim output As MemoryStream = New MemoryStream
            Dim wr As PdfWriter = PdfWriter.GetInstance(doc, output)
            doc.Open()
            Dim tbl As New PdfPTable(7)  'set 7 columns in table
            tbl.WidthPercentage = 100
            Dim cp() As Integer = {15, 15, 15, 15, 15, 15, 10}
            tbl.SetWidths(cp)
            'write header
            For x = 0 To gvUsers.Columns.Count - 1
                Dim cell As New PdfPCell(New Phrase(gvUsers.Columns(x).HeaderText.ToString, mf))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.VerticalAlignment = Element.ALIGN_MIDDLE
                cell.FixedHeight = 45.0F
                cell.BackgroundColor = New Color(System.Drawing.ColorTranslator.FromHtml("#a52a2a"))
                tbl.AddCell(cell)
            Next
            mf = New iTextSharp.text.Font(ft, 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK)
            'write content of table
            For x = 0 To gvUsers.Rows.Count - 1
                If gvUsers.Rows(x).RowType = DataControlRowType.DataRow Then
                    For y = 0 To gvUsers.Columns.Count - 1
                        Dim cellText = Server.HtmlDecode(gvUsers.Rows(x).Cells(y).Text)
                        Dim cell As New PdfPCell(New Phrase(cellText, mf))
                        cell.HorizontalAlignment = Element.ALIGN_CENTER
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE
                        cell.FixedHeight = 25.0F
                        tbl.AddCell(cell)
                    Next
                End If
            Next
            doc.Add(tbl)
            doc.Close()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "attachment;filename=test.pdf")
            Response.BinaryWrite(output.ToArray())
        End Sub
