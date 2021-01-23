    DateTimePicker d1;
    DateTimePicker d2;
    public void ComputeDifference()
    {
        TimeSpan diff = d2.Value - d1.Value;
        int days = diff.Days + 1;
    }
