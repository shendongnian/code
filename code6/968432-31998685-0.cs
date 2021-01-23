    'CREATE TWO PDFPTABLES
     Dim tblNested1 As New PdfPTable(1)
     Dim tblNested2 As New PdfPTable(3)
     'CREATE CELLS WITH NO BORDER AND ADD THEM TO TABLE2
     Dim cellNested1 = New PdfPCell(New Phrase("CELL1"))
     cellNested1.Border = 0
     tblNested2.AddCell(cellNested1)
     Dim cellNested2 = New PdfPCell(New Phrase("CELL2"))
     cellNested2.Border = 0
     tblNested2.AddCell(cellNested2)
     Dim cellNested3 = New PdfPCell(New Phrase("CELL3"))
     cellNested3.Border = 0
     tblNested2.AddCell(cellNested3)
     'APPEND TABLE2 TO A CELL WITH DEFAULT BORDER
      Dim cell1 As New PdfPCell
      cell1.AddElement(tblNested2)
      tblNested1.AddCell(cell1)
      document.Add(tblNested1)
                       
