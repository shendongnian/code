    List<dynamic> MaterialRequestContractorDetails = new List<dynamic>
    {
        new { MaterialRequestContractorId = 1, MaterialDescriptionId = 1, LineId = 1, SheetId = 1},
        new { MaterialRequestContractorId = 2, MaterialDescriptionId = 2, LineId = 2, SheetId = 2},
    };
    List<dynamic> MaterialDescriptions = new List<dynamic>
    {
        new { Id = 1 }, new { Id = 2 },
    };
    List<dynamic> Lines = new List<dynamic> { new { Id = 1 } };
    List<dynamic> Sheets = new List<dynamic> { new { Id = 1 } };
    List<dynamic> Joints = new List<dynamic> { new { SheetId  = 1, Id = 1 } };
    List<dynamic> TestPackageJoints = new List<dynamic>
    {
        new { Id = 1, TestPackageId = 1 },
        new { Id = 1, TestPackageId = 2 },
    };
    List<dynamic> TestPackages = new List<dynamic>
    {
        new { Id = 1 }, new { Id = 2 },
    };
    int MRCId = 1;
