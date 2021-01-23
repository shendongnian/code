    [IgnoreFirst(1)]
    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    public class Account
    {
       [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
       public string AccountName;
       [FieldValueDiscarded]
       [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
       public string Dummy;
    }
