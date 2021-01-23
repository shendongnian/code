    var response = controller.GetDeliveryTypes();
    
    Assert.IsNotNull(response);
    object content = response
      .GetType()
      .GetProperty("Content")
      .GetValue(response);
