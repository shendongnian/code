    public void SetRange(float? min, float? max)
    {
        if (min < 0f || max < 0f || min > 100f || max > 100f)
          throw new ArgumentOutOfRangeException();
        if (min >= max)
          throw new WrongElementValueException("Min must be greater than max!");
        Min = min;
        Max = max;
        if(min.HasValue && max.HasValue)
        {
            Average = (min + max)/2f;
            HasValue = true;
        }
        else
        {
          Average = null;
          HasValue = false;
        }
    }
