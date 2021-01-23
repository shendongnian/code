    HealthHabitat.ViewModels.Status status = HealthHabitat.ViewModels.Status.Dispatched;
    Enum.TryParse(delivery.Status.ToString(), out status);
    DeliveryVM model = new DeliveryVM()
    {
        ID = delivery.DeliveryID,
        DriverID = delivery.DriverID,
        Status = status;
    };
