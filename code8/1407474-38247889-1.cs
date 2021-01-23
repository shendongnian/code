    foreach (CustomProperty cp in MyExcelSheet.CustomProperties)
    {
        if (cp.Name == "MyKey")
        {
            cp.Delete();
        }
    }
