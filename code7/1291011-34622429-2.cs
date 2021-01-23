    void entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Stats.CurrentHealth")
        {
            Message.Write("Stats.CurrentHealth property changed!");
            DeathCheck((Entity)sender);
        }
    }
