    var culture = CultureInfo.CurrentCulture;
    var fmt = culture.DateTimeFormat;
    Debug.WriteLine("Current culture: " + culture.Name);
    foreach (var prop in fmt.GetType().GetProperties().Where(p => p.Name.EndsWith("Pattern")))
    {
        var pattern = prop.GetValue(fmt) as string;
        Debug.WriteLine("{0,-35}: {1,-35} - {2}", prop.Name, pattern, DateTime.Now.ToString(pattern));
    }
