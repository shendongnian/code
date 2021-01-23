    public bool HasProperty(Object o, string propertyName)
    {
        return o.GetType().GetProperty(propertyName) != null;
    }
...
    dynamic t = new
                  {
                validProperty = "value",
                  };
                  
    MessageBox.Show(HasProperty(t, "invalidProperty")?"true":"false");
    MessageBox.Show(HasProperty(t, "validProperty")  ?"true":"false");
