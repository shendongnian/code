        public FormatType Format
        {
            get { return _format; }
            set
            {
                // red line under value > 2.
                if (value < 0 || (int)value > 2) throw new FileParseException(ParseError.Format);
                _format = value;
            }
        }
