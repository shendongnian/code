    public void PrintAlignedText(string s, AlignmentConstants Alignment) {
            switch (Alignment) {
                case vbCenter:
                    Printer.CurrentX = (Printer.ScaleWidth - Printer.TextWidth(s));
                    2;
                    break;
                case vbLeftJustify:
                    Printer.CurrentX = 0;
                    break;
                case vbRightJustify:
                    Printer.CurrentX = (Printer.ScaleWidth - Printer.TextWidth(s));
                    break;
            }
            Printer.Print;
            s;
        }
