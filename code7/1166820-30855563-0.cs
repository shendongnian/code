    DeliveryExpirationRepository.Add(new DeliveryPendingConfirmation
    {
        EmailConfirmationId = newGuid,
        DeliveryDate = DateTime.UtcNow.AddHours(48),
    });
