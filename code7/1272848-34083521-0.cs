    public ActionResult AddressAndPayment(FormCollection values) // <-- here
    {
        // ...
        if (string.Equals(values["PromoCode"], PromoCode,
            StringComparison.OrdinalIgnoreCase) == false)
        {
            // ...
        }
        // ...
    }
