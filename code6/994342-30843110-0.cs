    void SwapTables()
    {
        RenameMainTableToTemporary();
        RenameStaginTableToMain();
        RenameTemporaryToStaging();
    }
