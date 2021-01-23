    for (int i = 0; i < col.Length; ++i)  
    {  
       Cell cell = new Cell(new Phrase(col[i], new iTextSharp.text.Font(iTextSharp.text.Font.COURIER, 5)));  
       cell.Header = true;  
       cell.BackgroundColor = new iTextSharp.text.Color(204, 204, 204);       
       table.AddCell(cell);  
    }
