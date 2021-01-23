    /// <summary>
    /// The collection of drivers just changed: add or remove
    /// </summary>
    /// <param name="sender">Sernder of the Event.</param>
    /// <param name="e">Event Arguments.</param>
    private void Drivers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Only Delete
        if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach (FormulaOneDriver driver in e.OldItems)
            {
                driver.Delete();
            }
        }
    }
