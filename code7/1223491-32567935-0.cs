    public string[] DynamicStringArray
    {
        get
        {
            for (int i=1; i <= this.NumberOfThings; i++)
                yield return string.Format(this._BaseName, i);
        }
    }
