    if (!IsInt(facilityID))
        isDataValid.Second = "facilityID" + errorMessage + ",";
    if (!IsInt(facilityDockDoorID))
        isDataValid.Second += "facilityDockDoorID" + errorMessage + ",";
    if (!IsInt(increment))
        isDataValid.Second += "increment" + errorMessage + ",";
    if (!IsInt(hoursOfOperationId))
        isDataValid.Second += "hoursOfOperationId" + errorMessage + ",";
    if (!IsInt(updatedById))
        isDataValid.Second += "updatedById" + errorMessage + ",";
    if (!IsTime(startTime))
        isDataValid.Second += "startTime" + errorMessage + ",";
    if (!IsTime(endTime))
        isDataValid.Second += "endTime" + errorMessage + ",";
    if (!IsValidDockDoorServiceType(dockDoorServiceType))
        isDataValid.Second += "dockDoorServiceType" + errorMessage + ",";
    if (!IsValidDayOfTheWeek(daysOfTheWeek))
        isDataValid.Second += "daysOfTheWeek" + errorMessage + ",";
    isDataValid.First = isDataValid.Second.Length == 0;
    return isDataValid;
