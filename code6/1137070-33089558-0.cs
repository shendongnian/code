    public static class AcroExtensions
    {
    	public static AcroPDFLib.IAcroAXDocShim AsAcroPDF(this AxAcroPDFLib.AxAcroPDF source)
    	{
    		return (AcroPDFLib.IAcroAXDocShim)source.GetOcx();
    	}
    }
