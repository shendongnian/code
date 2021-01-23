    for (var i = 0; i < 10; i++) {
        if (i == 0) {
            table1.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
        }
        else {
            table1.DefaultCell.BackgroundColor = BaseColor.BLUE;
        }
        table1.AddCell(new Phrase("NO"));
        table1.AddCell(new Phrase("Date & Day"));
        table1.AddCell(new Phrase("Hr"));
        table1.AddCell(new Phrase("Topics to be Covered"));
    }
