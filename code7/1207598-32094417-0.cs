    var found = dtRecipients.AsEnumerable()
        .Where(row => String.Equals(
            new String(
               (row.Field<string>("RecipientId") ?? "").Trim()
                .Where(c => !char.IsControl(c))
                .ToArray()), 
             "marcus", StringComparison.OrdinalIgnoreCase));
