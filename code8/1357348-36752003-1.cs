    using NodaTime;
    using NodaTime.Text;
    ...
    var pattern = LocalDateTimePattern.CreateWithInvariantCulture("M/d/yyyy HH:mm:ss");
    var result = pattern.Parse("4/20/2016 11:30:00");
    if (!result.Success)
    {
        // handle error
    }
    LocalDateTime ldt = result.Value;
