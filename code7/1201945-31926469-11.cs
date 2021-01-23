    private void ThingsFiltered_OnFilter(object sender, FilterEventArgs e)
    {
        Thing thing = e.Item as Thing;
        if (thing.Name == "Maxime")
        {
            e.Accepted = true;
        }
        else
        {
            e.Accepted = false;
        }
    }
 
