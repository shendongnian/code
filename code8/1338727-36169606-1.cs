    container.RegisterType<IShip, UPS>("UPS");
    container.RegisterType<IShip, FedEX>("FedEX");
    container.RegisterType<IShip, Purolator>("Purolator");
    public IShip GetShippment(string c)
    {
        if (c == "GB" || c == "FR")
            return container.Resolve<IShip>("UPS");
        if (c == "US")
            return container.Resolve<IShip>("FedEX");
        if (c == "CA")
            return container.Resolve<IShip>("Purolator");
        throw new NotImple,entedException();
    }
    ...
    var shippment = GetShippment("CA");
    shippment.Ship();
