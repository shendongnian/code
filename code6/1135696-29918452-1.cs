    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    <#
    	// consider including the namespace in the class names.
    	var product = new Mapper("Product", "ProductEntity") { "Name", {"Id", "ServiceId"} };
    	var person = new Mapper("Person", "DbPerson") { "Employee", {"Name", "FullName"}, {"Addredd", "HomeAddress"} };
    
    	var mappings = new [] {product, person};
    #>
    // !!!
    // !!!  Do not modify this file, it is automatically generated. Change the .tt file instead.     !!!
    // !!!
    namespace Your.Mapper
    {
    	partial class Mapper
    	{
    		<# foreach(var mapping in mappings) { 
    		#>/// <summary>
            /// Set <paramref name="target"/> properties by copying them from <paramref name="source"/>.
            /// </summary>
            /// <remarks>Mapping:<br/>
    		<#foreach(var property in mapping){
    		#>/// <see cref="<#=mapping.SourceType#>.<#=property.SourceProperty#>"/> → <see cref="<#=mapping.TargetType#>.<#=property.TargetProperty#>"/> <br/>
    		<#}
            #>/// </remarks>
            /// <returns><c>true</c> if any property was changed, <c>false</c> if all properties were the same.</returns>
    		public bool ModifyExistingEntity(<#=mapping.SourceType#> source, <#=mapping.TargetType#> target)
    		{
    			bool dirty = false;
    			<# foreach(var property in mapping) {
    			#>if (target.<#=property.TargetProperty#> != source.<#=property.SourceProperty#>)
    			{
    				dirty = true;
    				target.<#=property.TargetProperty#> = source.<#=property.SourceProperty#>;
    			}			
    			<#}
    			#>return dirty;
    		}
    		<#
    		 } 
    		#>
    
    	}
    }
    
    <#+
    class Mapper : IEnumerable<PropertyMapper>
    {
        private readonly List<PropertyMapper> _properties;
    
        public Mapper(string sourceType, string targetType)
        {
            SourceType = sourceType;
            TargetType = targetType;
            _properties = new List<PropertyMapper>();
        }
    
        public string SourceType { get; set; }
        public string TargetType { get; set; }
    
        public void Add(string fieldName)
        {
            _properties.Add(new PropertyMapper {SourceProperty = fieldName, TargetProperty = fieldName});
        }
    
        public void Add(string sourceProperty, string targetProperty)
        {
            _properties.Add(new PropertyMapper { SourceProperty = sourceProperty, TargetProperty = targetProperty });
        }
    
        IEnumerator<PropertyMapper> IEnumerable<PropertyMapper>.GetEnumerator() { return _properties.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return _properties.GetEnumerator(); }
    }
    
    class PropertyMapper
    {
        public string SourceProperty { get; set; }
        public string TargetProperty { get; set; }
    }
    #>
