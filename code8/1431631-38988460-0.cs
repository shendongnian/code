    public IEnumerable<PropertyInfo> GetVariance(Client user)
    {
        foreach (PropertyInfo pi in user.GetType().GetProperties()) {
            object valueUser = typeof(Client).GetProperty (pi.Name).GetValue (user);
            object valueThis = typeof(Client).GetProperty (pi.Name).GetValue (this);
            if (valueUser != null && !valueUser.Equals(valueThis))
                yield return pi;
        }
    }
    IEnumerable<PropertyInfo> variances = data1.GetVariance (data2);
    foreach (PropertyInfo pi in variances)
          Console.WriteLine (pi.Name);
