    internal class DataModel : Interface1, Interface2 {
	
		 internal DataModel(_xml)
		 {
			this.xml = _xml;
		 }
		
		private xml {get; set;}
		 
    	public Interface1.Property1 {get; set;}
    		
    	public Interface2.Property2 {get; set;}
    }
    
	//expose DataModel only via below Helper class
    public class DataModelHelper {
      
       public Interface1 GetModel_1(string xml)
       {
    	Interface1 i1 = new  DataModel(xml);
    	return i1;
       }
    
       public Interface2 GetModel_2(xml)
       {
    	Interface2 i2 = new  DataModel(xml);
    	return i2;
       }
    }
