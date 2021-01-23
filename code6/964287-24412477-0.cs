    private static readonly UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0,
                                                     DateTimeKind.Utc);
    ...
    long millis = ...;
    DateTime dateFromJavaApp = UnixEpoch + Timespan.FromMilliseconds(millis);
