     private static LPFLogger GetLPFLogger(int value)
        {
            var lstEnum = Enum.GetValues(typeof(LPFLogger)).Cast<int>().ToList();
            if (lstEnum.Any(s => s == value))
                return (LPFLogger)value;
            return LPFLogger.None;
        }
