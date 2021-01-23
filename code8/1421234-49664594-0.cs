	public class TaxSlab
	{
		public int TaxId {get;set;}
		public double MinRangeAmount {get;set;}
		public double MaxRangeAmount {get;set;}
		public int TaxRate {get;set;}
		public double TaxRateAmount {get;set;}
		
	}
	  class Program
    	{
    	static List<TaxSlab> taxSlab= new List<TaxSlab>();
    	
    	static void LoadTaxSettings()
    	{
    		taxSlab.AddRange(new TaxSlab[]{
    			new TaxSlab{TaxId=1,MinRangeAmount=0,MaxRangeAmount=250000,TaxRate=0,TaxRateAmount=0},
    			new TaxSlab{TaxId=2,MinRangeAmount=250000,MaxRangeAmount=500000,TaxRate=10,TaxRateAmount=250000*10/100},
    			new TaxSlab{TaxId=3,MinRangeAmount=500000,MaxRangeAmount=1000000,TaxRate=20,TaxRateAmount=500000*20/100},
    			new TaxSlab{TaxId=4,MinRangeAmount=1000001,MaxRangeAmount=999999999,TaxRate=30,TaxRateAmount=2999999*30/100},
    		                 
    		  });
    	}
    	
    	static double GetTaxAmount(double taxableAmount)
    	{
			/*    		
    		 return taxSlab.Where(x=>x.MinRangeAmount<taxableAmount).Select(x=> new {Tax=
    		                                                               		(
    		                                                               			(x.MinRangeAmount<taxableAmount && taxableAmount<x.MaxRangeAmount) ?
    		                                                               			Math.Round(((taxableAmount-x.MinRangeAmount)*x.TaxRate/100),0) :
    		                                                               			Math.Round(x.TaxRateAmount,0)
    		                                                               		)
    		                                                               }).Sum(x=>x.Tax);
			*/
			
			
    		 return taxSlab.Where(x=>x.MinRangeAmount<taxableAmount).Select(x=> new {Tax=
    		                                                               		(
    		                                                               			(x.MinRangeAmount<taxableAmount && taxableAmount<x.MaxRangeAmount) ?
    		                                                               			Math.Round(((taxableAmount-x.MinRangeAmount)*x.TaxRate/100),0) :
    		                                                               			Math.Round((x.MaxRangeAmount-x.MinRangeAmount)*x.TaxRate/100,0)
    		                                                               		)
    		                                                               }).Sum(x=>x.Tax);
    
    	}
        static void Main(string[] args)
        {
	LoadTaxSettings();
	Console.WriteLine("720000 : {0}" ,GetTaxAmount(720000));
	Console.WriteLine("750000 : {0}" ,GetTaxAmount(750000));
	Console.WriteLine("850000 : {0}" ,GetTaxAmount(850000));
	Console.WriteLine("950000 : {0}" ,GetTaxAmount(950000));
        }
    }
