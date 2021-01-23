    public class  OrcamentoInsumoConfig : EntityTypeConfiguration<OrcamentoInsumo>
    {
    	public OrcamentoInsumoConfig()
    	{ 
    		ToTable("OrcamentoInsumo");
    
    		HasKey(o => o.OrcamentoId);
    
    		...
    	}
    }
    public class  INOCConfig : EntityTypeConfiguration<INOC>
    {
    	public INOCConfig()
    	{
    		ToTable("INOC");
    
    		HasKey(i => i.OrcamentoId);
    
    		...
    	}
    }
    public class  IACConfig : EntityTypeConfiguration<IAC>
    {
    	public IACConfig()
    	{
    		ToTable("IACC");
    
    		HasKey(i => i.OrcamentoId);
    
    		...
    	}
    }
