    (from ........
    select new
    {
        ItemCode = materialDescription.ItemCode,
        MaterialDescription = materialDescription.Description,
        SheetNumber = sheet.SheetNumber,
        LineNumber = line.LineNumber,
        TestPackageNumber = testPackage.PackageNumber,
        QuantityDeliverToMember = internalMaterialIssueVocherDetail.QuantityDeliverToMember.ToString(),
        Size = materialDescription.Size1
    }).Distinct().Select(x => new ViewIMIV()
    {
        ItemCode = x.ItemCode,
        MaterialDescription = x.MaterialDescription,
        SheetNumber = x.SheetNumber,
        LineNumber = x.LineNumber,
        TestPackageNumber = x.TestPackageNumber,
        QuantityDeliverToMember = x.QuantityDeliverToMember,
        Size = x.Size
    }).ToList();
