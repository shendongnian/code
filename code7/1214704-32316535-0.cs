    string obje = String.Empty;
    long userId = 0;
    long objNewId = 0;
    long objOldId = 0;
    string action = String.Empty;
    
    obje = ConstantParams.WCFLOG_APPLICATION_Foo;
    SuperclassDto newDto = (SuperclassDto)response.Data;
    SuperclassDto oldDto = (SuperclassDto)oldObject;
    userId = newFoo.UserApplicationId;
    objNewId = newDto.Id;
    objOldId = oldDto.Id;
    action = (objOldId == 0) ? ConstantParams.WCFLOG_APPLICATION_NEW : ConstantParams.WCFLOG_APPLICATION_UPD;
    
    string message = Helper.GenerateMessage(action, obje, userId, objNewId);
