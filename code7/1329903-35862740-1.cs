    get
    {
        string str = this.FormulaA1;
        if (!XLHelper.IsNullOrWhiteSpace(str))
        {
            string str2;
            string sName;
            if (str[0] == '{')
            {
                str = str.Substring(1, str.Length - 2);
            }
            if (str.Contains<char>('!'))
            {
                sName = str.Substring(0, str.IndexOf('!'));
                if (sName[0] == '\'')
                {
                    sName = sName.Substring(1, sName.Length - 2);
                }
                str2 = str.Substring(str.IndexOf('!') + 1);
            }
            else
            {
                sName = this.Worksheet.Name;
                str2 = str;
            }
            if (this._worksheet.Workbook.WorksheetsInternal.Any<XLWorksheet>(w => (string.Compare(w.Name, sName, true) == 0)) && XLHelper.IsValidA1Address(str2))
            {
                return this._worksheet.Workbook.Worksheet(sName).Cell(str2).Value;
            }
            object obj2 = this.Worksheet.Evaluate(str);
            IEnumerable enumerable = obj2 as IEnumerable;
            if ((enumerable != null) && !(obj2 is string))
            {
                using (IEnumerator enumerator = enumerable.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        return enumerator.Current;
                    }
                }
            }
            return obj2;
        }
        string s = this.HasRichText ? this._richText.ToString() : this._cellValue;
        if (this._dataType == XLCellValues.Boolean)
        {
            return (s != "0");
        }
        if (this._dataType == XLCellValues.DateTime)
        {
            return DateTime.FromOADate(double.Parse(s));
        }
        if (this._dataType == XLCellValues.Number)
        {
            return double.Parse(s);
        }
        if (this._dataType == XLCellValues.TimeSpan)
        {
            return TimeSpan.Parse(s);
        }
        return s;
    }
