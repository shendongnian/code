    public string ConcatenatedUserNumbers
        {
            get
            {
                if (ContactNumbers != null && ContactNumbers.Any())
                {
                    return string.Join("; ", ContactNumbers.Select(a => a.Number));
                }
                return string.Empty;
            }
        }
