    var firstConditionColumns = new[] {
        UtilityEntity.FranceColumnGS,
        UtilityEntity.FranceColumnHQ,
        UtilityEntity.FranceColumnIO,
        UtilityEntity.FranceColumn.JM };
    var secondConditionColumns = new[] {
        UtilityEntity.FranceColumnHB,
        UtilityEntity.FranceColumnHZ,
        UtilityEntity.FranceColumnIX,
        UtilityEntity.FranceColumnJV };
    if (firstConditionColumns.Any(o => Convert.ToString(dRow[o]) == "x") &&
        secondConditionColumns.Any(o => Convert.ToString(dRow[o]) == "x"))
    {
        excelWorksheet.Cells["AV" + rowIndex].Value = "both";
    }
