    var persian = CalendarSystem.GetPersianCalendar();
    // The pattern takes the calendar system from the default value
    var sampleDate = new LocalDate(1392, 1, 1, persian);
    var pattern = LocalDatePattern.CreateWithInvariantCulture("yyyy/M/d")
                                  .WithTemplateValue(sampleDate);
    var date = pattern.Parse("1392/02/30").Value;
    Console.WriteLine(LocalDatePattern.IsoPattern.Format(date));
