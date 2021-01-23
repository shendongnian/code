    var query = classASheet.getClassFromExcelPivotedValuedreductionBy<tbl_Life_Reduction_By>(25, 1, 33, 4, lifeReductionByClassMapper);
    foreach (var item in query)
    {
        item.Class = classesValue[x];
        item.UUID = censusSheet.GetValue(25, 27).ToString();
    }
