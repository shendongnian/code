	//Test if the cell A1 has a validation list
	var sourceDv = worksheet.DataValidations["A1"];
	if (sourceDv != null)
	{
		//Test for each type
		if (sourceVal.ValidationType.Type == eDataValidationType.List)
		{
			var destCell = worksheet.Cells["A10"];
			var destVal = worksheet.DataValidations.AddListValidation(destCell.Address);
			destVal.Formula.ExcelFormula = sourceVal.Formula.ExcelFormula;
		}
		else
		{
			throw new NotImplementedException(sourceVal.ValidationType.Type.ToString());
		}
	}
