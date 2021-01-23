    var carCache = DataCache.GetInstance().GeTCarById(1);
        entity =new Vehicle
                                    {
        
                                        IsActive = true,
                                        Car.value1 = carCache.value1,
                                        Car.value2 = carCache.value2
                                    };
