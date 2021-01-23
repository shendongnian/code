    var dt1 = new DateTime(2015, 01, 01, 00, 00, 00); // defaults to DateTimeKind.Unspecified
    var dt2 = new DateTime(2015, 01, 01, 00, 00, 00, DateTimeKind.Local);
    var dt3 = new DateTime(2015, 01, 01, 00, 00, 00, DateTimeKind.Utc);
    var dt4 = new DateTime(2015, 01, 01, 00, 00, 00, DateTimeKind.Unspecified);
    Debug.WriteLine(dt1.Kind); // writes "Unspecified"
    Debug.WriteLine(dt2.Kind); // writes "Local"
    Debug.WriteLine(dt3.Kind); // writes "Utc"
    Debug.WriteLine(dt4.Kind); // writes "Unspecified"
