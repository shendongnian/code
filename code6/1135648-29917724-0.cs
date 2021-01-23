     private static Stylesheet CreateStylesheet()
    {
       Stylesheet ss = new Stylesheet();
            Font font0 = new Font();         // Default font
            Font font1 = new Font();         // Bold font
            Bold bold = new Bold();
            font1.Append(bold);
            Fonts fonts = new Fonts();      // <APENDING Fonts>
            fonts.Append(font0);
            fonts.Append(font1);
            // <Fills>
            Fill fill0 = new Fill();        // Default fill
            Fills fills = new Fills();      // <APENDING Fills>
            fills.Append(fill0);
            // <Borders>
            Border border0 = new Border();     // Defualt border
            Borders borders = new Borders();    // <APENDING Borders>
            borders.Append(border0);
            CellFormat cellformat0 = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 }; // Default style : Mandatory | Style ID =0
            CellFormat cellformat1 = new CellFormat(){FontId = 1};
            CellFormats cellformats = new CellFormats();
            cellformats.Append(cellformat0);
            cellformats.Append(cellformat1);
            ss.Append(fonts);
            ss.Append(fills);
            ss.Append(borders);
            ss.Append(cellformats);
            
            
            return ss;
    }
