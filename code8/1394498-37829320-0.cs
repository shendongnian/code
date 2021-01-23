    Chunk c1 = new Chunk("This single", new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.BLACK)));
                Chunk c2 = new Chunk("word", new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, Font.BOLD, BaseColor.BLACK)));
                Chunk c3 = new Chunk("should be Bold", new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.BLACK)));
    
                Paragraph p2 = new Paragraph();
                p2.Add(c1);
                p2.Add(c2);
                p2.Add(c3);
    
     List lst_note = new List(List.ORDERED);
    
     lst_note.IndentationLeft = 10f;
     lst_note.Add(new iTextSharp.text.ListItem(p2);
    
     disclaimer.Add(lst_note);
