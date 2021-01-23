    // user of your class
    yourClass.DateCustomViewModels.Add(new DateViewModel()); // goes nowhere
    yourClass.DateCustomViewModels.RemoveAt(0); // removes nothing
    // or trying to be smart
    for (int i = 0; i < yourClass.DateCustomViewModels.Cout; i++
    {
        var model = yourClass.DateCustomViewModels[i];
    }
    // etc.
