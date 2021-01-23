    if (!IsInt(facilityID))
    {
        isDataValid.Second = "facilityID" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsInt(facilityDockDoorID))
    {
        isDataValid.Second += "facilityDockDoorID" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsInt(increment))
    {
        isDataValid.Second += "increment" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsInt(hoursOfOperationId))
    {
        isDataValid.Second += "hoursOfOperationId" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsInt(updatedById))
    {
        isDataValid.Second += "updatedById" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsTime(startTime))
    {
        isDataValid.Second += "startTime" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsTime(endTime))
    {
        isDataValid.Second += "endTime" + errorMessage + ",";
        return isDataValid;
    }
    if (!IsValidDockDoorServiceType(dockDoorServiceType))
    {
        isDataValid.Second += "dockDoorServiceType" + errorMessage + ",";
        return isDataValid;
    }
    if (IsValidDayOfTheWeek(daysOfTheWeek))
    {
        isDataValid.First = true;
    }
    else
    {
        isDataValid.Second += "daysOfTheWeek" + errorMessage + ",";
    }
    return isDataValid;
