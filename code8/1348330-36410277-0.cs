    var theEnteredAdress = adressEntry.Text;
    Geocoder gc = new Geocoder();
    Task<IEnumerable<Position>> result =
        gc.GetPositionsForAddressAsync(theEnteredAdress); //cannot enter the variable value here. Cannot convert string expression to type: Xamarin.Forms.Maps.Position
    System.Diagnostics.Debug.WriteLine(theEnteredAdress);
