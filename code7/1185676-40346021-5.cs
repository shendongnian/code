    private static void GeneratePivotTables(WorkbookPart workbookPart, WorksheetPart worksheetPart,
    	XLWorksheet xlWorksheet,
    	SaveContext context)
    {
    	var pivotCaches = workbookPart.Workbook.GetFirstChild<PivotCaches>();
    	foreach (var pt in xlWorksheet.PivotTables)
    	{
    		var ptCdp = context.RelIdGenerator.GetNext(RelType.Workbook);
    
    		var pivotTableCacheDefinitionPart = workbookPart.AddNewPart<PivotTableCacheDefinitionPart>(ptCdp);
    		GeneratePivotTableCacheDefinitionPartContent(pivotTableCacheDefinitionPart, pt);
    
    		if (pivotCaches == null)
    			workbookPart.Workbook.AppendChild(pivotCaches = new PivotCaches());
    		var pivotCache = new PivotCache { CacheId = (uint)pivotCaches.Count(), Id = ptCdp };
    		pivotCaches.AppendChild(pivotCache);
    
    		var pivotTablePart =
    			worksheetPart.AddNewPart<PivotTablePart>(context.RelIdGenerator.GetNext(RelType.Workbook));
    		GeneratePivotTablePartContent(pivotTablePart, pt);
    		pivotTablePart.PivotTableDefinition.CacheId = pivotCache.CacheId;
    		pivotTablePart.AddPart(pivotTableCacheDefinitionPart, context.RelIdGenerator.GetNext(RelType.Workbook));
    	}
    }
