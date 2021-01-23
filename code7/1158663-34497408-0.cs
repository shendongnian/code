	    public FormattedString CustomFormattedText
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                        new Span { Text = Sum, FontAttributes=FontAttributes.Italic, FontSize="10" },
                        new Span { Text = Info, FontSize="10" } }
                };
            }
            set { }
        }
