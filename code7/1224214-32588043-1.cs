    if (dbRow.AnyColIsChecked(UtilityEntity.FranceColumnGS,
            UtilityEntity.FranceColumnHQ,
            UtilityEntity.FranceColumnIO,
            UtilityEntity.FranceColumn.JM) &&
        dbRow.AnyColIsChecked(UtilityEntity.FranceColumnHB,
            UtilityEntity.FranceColumnHZ,
            UtilityEntity.FranceColumnIX,
            UtilityEntity.FranceColumnJ))
    {
        ...
    }
