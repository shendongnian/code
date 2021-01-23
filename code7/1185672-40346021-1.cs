    private static void GeneratePivotTables(WorkbookPart workbookPart, WorksheetPart worksheetPart,
        XLWorksheet xlWorksheet,
        SaveContext context)
    {
        foreach (var pt in xlWorksheet.PivotTables)
        {
            var ptCdp = context.RelIdGenerator.GetNext(RelType.Workbook);
    
            var pivotTableCacheDefinitionPart = workbookPart.AddNewPart<PivotTableCacheDefinitionPart>(ptCdp);
            GeneratePivotTableCacheDefinitionPartContent(pivotTableCacheDefinitionPart, pt);
    
            var pivotCaches = new PivotCaches();
            var pivotCache = new PivotCache {CacheId = 0U, Id = ptCdp};
    
            pivotCaches.AppendChild(pivotCache);
    
            workbookPart.Workbook.AppendChild(pivotCaches);
    
            var pivotTablePart =
                worksheetPart.AddNewPart<PivotTablePart>(context.RelIdGenerator.GetNext(RelType.Workbook));
            GeneratePivotTablePartContent(pivotTablePart, pt);
    
            pivotTablePart.AddPart(pivotTableCacheDefinitionPart, context.RelIdGenerator.GetNext(RelType.Workbook));
        }
    }
