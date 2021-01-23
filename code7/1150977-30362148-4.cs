    public string PrintCrate()
    {
        using (var enumerator = sodaCans.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                return null
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(enumerator.Current ?? "EmptySpot");
            while (enumerator.MoveNext())
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(enumerator.Current ?? "EmptySpot");
            }
            return StringBuilder.ToString();
        }
    }
