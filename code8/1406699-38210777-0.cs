    if(!IsInt(facilityID))
    {
        isDataValid.Second = "facilityID" + errorMessage + ",";
    }
    if(!IsInt(facilityDockDoorID))
    {
        isDataValid.Second += "facilityDockDoorID" + errorMessage + ",";
    }
