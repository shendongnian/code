    public string[] DynamicStringArray
    {
        get
        {
            string[] result = new string[this.NumberOfThings];
            for (int i = 0; i < this.NumberOfThings; i++)
            {
                result[i] = string.Format(this._BaseName, i + 1));
            }
            return result;
        }
    }
