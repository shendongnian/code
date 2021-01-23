    /// <summary>
    /// Gets or sets the value of the specified application settings property.
    /// </summary>
    /// 
    /// <returns>
    /// If found, the value of the named settings property; otherwise, null.
    /// </returns>
    /// <param name="propertyName">A <see cref="T:System.String"/> containing the name of the property to access.</param><exception cref="T:System.Configuration.SettingsPropertyNotFoundException">There are no properties associated with the current wrapper or the specified property could not be found.</exception><exception cref="T:System.Configuration.SettingsPropertyIsReadOnlyException">An attempt was made to set a read-only property.</exception><exception cref="T:System.Configuration.SettingsPropertyWrongTypeException">The value supplied is of a type incompatible with the settings property, during a set operation.</exception><exception cref="T:System.Configuration.ConfigurationErrorsException">The configuration file could not be parsed.</exception><filterpriority>2</filterpriority>
    public override object this[string propertyName]
    {
      get
      {
        if (!this.IsSynchronized)
          return this.GetPropertyValue(propertyName);
        lock (this)
          return this.GetPropertyValue(propertyName);
      }
      set
      {
        SettingChangingEventArgs e = new SettingChangingEventArgs(propertyName, this.GetType().FullName, this.SettingsKey, value, false);
        this.OnSettingChanging((object) this, e);
        if (e.Cancel)
          return;
        base[propertyName] = value;
        this.OnPropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
      }
    }
