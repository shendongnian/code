    <#@ parameter name="XmlFileName" type="System.String" #>
    <#
    	
    	XmlSerializer serializer = new XmlSerializer(typeof(MyObject));
    	StreamReader sr = new StreamReader(this.XmlFileName);
        MyObject O = (MyObject)serializer.Deserialize(sr);
    	
    #>
    using System;
    public class <#= O.Name #> : BusinessObjectBase<<#= O.Name #>Data>
        {
            #region Construction
    		        
            private <#= O.Name #>() : base(true) {}
    
            /// <summary>
            /// Initializes a new instance of the <#= Utility.GetRefClassName(O.Name) #> class.
            /// </summary>
            /// <param name="data"></param>
            <#= Utility.GetRemarksComment2(O) #>
            internal <#= O.Name #>(<#= O.Name #>Data data) : base(data) {}
    
            #endregion
    
            #region <#= O.Name #> Data
    
    		<#
    		// Generate a property for each child.
    		foreach (MyObjectProperty objProp in O.Property)
    		{
    			if (objProp.GetAccess == "public")
    			{
    				objProp.GetAccess = ""; 
    			}
    			else
    			{
    				objProp.GetAccess = objProp.GetAccess + " ";
    			}
    
    			if (objProp.SetAccess == "public")
    			{
    				objProp.SetAccess = ""; 
    			}
    			else
    			{
    				objProp.SetAccess = objProp.SetAccess + " ";
    			}
    
    		#>/// <summary>
