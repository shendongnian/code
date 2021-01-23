    (from l in context.Languages
    join t in context.Translations on l.ISO639_ISO3166 equals t.ISO639_ISO3166).AsEnumerable()
    .Where(l => string.Equals(l.ApplicationName, applicationName, StringComparison.InvariantCultureIgnoreCase))
    .Select(new Translation
                  {
                      Key = t.Key,
                      Text = t.Text
                  }).ToListAsync();
