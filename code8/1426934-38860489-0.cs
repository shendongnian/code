    [TypeConverterAttribute(typeof(LengthConverter))]
    public Double LabelWidth
    {
        get { return (Double)GetValue(labelWidth); }
        set { SetValue(labelWidth, value); }
    }
