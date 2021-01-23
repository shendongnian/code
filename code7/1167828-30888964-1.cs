    private List<string> measureValues = null;
    public List<string> MeasureValues
    {
        get
        {
            if (measureValues == null)
                measureValues = new List<string>() { "Sum", "Average" };
    
            return measureValues;
        }
    }
