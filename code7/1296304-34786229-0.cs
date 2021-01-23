    public object Property1
    {
       if (isValid)
       {
           return "SomeString";
       }
       else
       {
           return DependencyProperty.UnsetValue;
       }
    }
