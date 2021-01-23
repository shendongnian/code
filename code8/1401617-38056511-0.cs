    public Validation(Func<Control, bool> isValid = null)
    {
        //How to set Custom??
        Custom = isValid ?? this.IsValid;
    }
    private bool IsValid(Control c)
    {
    }
