    using(var package = new ExcelPackage(new FileInfo(@"c:\temp\tmp.xlsx")))
    {
       var sheet=package.Workbook.Worksheets["my sheet"];
       var lender=model.Lender;
       sheet.Cells["C7"].Value=lender.ApprovedTerm;
       sheet.Cells["C8"].Value=lender.ContractRate;
       sheet.Cells["C9"].Value=lender.ApprovedLoanAmt;
       // calculate all formulas in the sheet
       sheet.Calculate();
    }
