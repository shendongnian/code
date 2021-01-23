    foreach(var artikel in artikels)
    {
        if (artikel.HasEpreis)
        {
            TempRechnung.ReplaceText("{2_ANR}", artikel.Nr);
            TempRechnung.ReplaceText("{2_BEZ}", artikel.Bez);
            // ...
        }
        else
        {
            // ...
        }
    }
