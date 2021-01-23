    private class DateAndTag // Can't use anonymous types as we have to pass method boundaries.
    {
      public DateTime Modified { get; set; }
      public string Modified { get; set; }
    }
    private static DateAndTagFromPending(Pending pn)
    {
      return new DateAndTag{Modified = pn.Modified, Tag = pn.Tag};
    }
    private static DateAndTagFromPreference(Preference pr)
    {
      return new DateAndTag{Modified = pr.Modified, Tag = pr.Tag};
    }
    private static DateTime GetModified(DateAndTag dt)
    { //it's possible to get the property into a method or delegate with reflection, but that's even worse.
      return dt.Modified;
    }
    //and now in the calling code;
    var lastModAndTag = ctx.Pending
      .Select(DateAndTagFromPending)
      .Union(ctx.Preferences.Select(DateAndTagFromPreference))
      .OrderByDescending(GetModified).FirstOrDefault();
