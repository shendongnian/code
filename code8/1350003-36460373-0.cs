    Map(t => t.AttemptStart).Name("Attempt Start")
        .ConvertUsing(new Func<CsvHelper.ICsvReaderRow, DateTime>(r =>
            {
                DateTime dateTimeValue;
                if (DateTime.TryParse(r["Attempt Start"], "MM/dd/yyyy HH:mm",
                    System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dateTimeValue))
                {
                    return dateTimeValue;
                }
                return null;
            }));
