    private  async void FilterPins (string filter)
    {
        map.Pins.Clear ();
        foreach(Pin p in myPins) {
            if (string.IsNullOrEmpty(filter) || (p.Label.Contains(filter))) {
                map.Pins.Add (p);
            }
        }
    }
