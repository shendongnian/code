    private  async void FilterPins (string filter)
    {
        map.Pins.Clear ();
        if (string.IsNullOrEmpty(filter) {
            map.Pins = myPins;
        } else {
            foreach(Pin p in myPins) {
                if (p.Label.Contains(filter)) {
                    map.Pins.Add (p);
                }
            }
        }
    }
