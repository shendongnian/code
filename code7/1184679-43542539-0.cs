    public DbSet GetDialDbSet(DialEnum type)
        {
            DbSet ret;
            switch (type)
            {
                default:
                case DialEnum.MAPPING_REASON:
                    ret = DialMappingReasons; 
                    break;
                case DialEnum.PROCESSING_INFORMATION:
                    ret = DialProcessingInformation;
                    break;
            }
            return ret;
        }
