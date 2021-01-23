    public int UpdateFrom1()
    {
        ContentDefinitionManager.AlterPartDefinition("DepositPart", part => part
            .Attachable());
        return 2;
    }
