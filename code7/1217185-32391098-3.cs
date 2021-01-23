    var allFormats = ...; // As before
    var allPatterns = allFormats
        .Select(format => LocalDateTimePattern.CreateWithInvariantCulture(format))
        .ToList();
    var matchingPatterns = allPatterns.Where(pattern => pattern.Parse(text).Success)
                                      .ToList();
