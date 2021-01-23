    public static bool Validate(int fieldID)
    {        
        return 
            MetadataManager.FieldRegistry.Any(f => f.ID == fieldID) &&
            fieldID > 1;
    }
