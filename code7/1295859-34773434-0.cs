    // Make sure the dto is adjusted to the tz.  This could be a no-op if it already is.
    DateTimeOffset adjusted = TimeZoneInfo.ConvertTime(dto, tz);
    // Then just get the wall time, stripping away the offset.
    // The resulting datetime has unspecified kind.
    DateTime dt = adjusted.DateTime;
    // Finally, call the datetime version of the function
    bool ambiguous = tz.IsAmbiguousTime(dt);
