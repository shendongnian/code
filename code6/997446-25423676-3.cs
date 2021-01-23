    void OnAbilitiesdataPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "AbilityEffect2")
        {
            rtb.Blocks.Clear();
            rtb.Blocks.Add((sender as Abilities_data).AbilityEffect2);
        }
    }
