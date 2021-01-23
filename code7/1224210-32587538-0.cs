    if (isX(UtilityEntity.FranceColumnGS) || isX(UtilityEntity.FranceColumnHQ) ...)
    {
       ...
    }
    
    
    private bool isX(int index)
    {
        return (Convert.ToString(dRow[index]) == "x");
    }
