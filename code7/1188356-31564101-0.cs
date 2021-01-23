    double ZahlAlsText;
            for (int i = 2; i < totalCols; i++) 'columns
            {
                for (int y = 2; y <= letztezeile + 1; y++) 'rows
                {
                    ZahlAlsText = double.Parse(range[y, i].Value.ToString());
                    range[y, i].Style.Numberformat.Format = "#,##0.00";
                    range[y, i].Value = ZahlAlsText;
                }
            }
