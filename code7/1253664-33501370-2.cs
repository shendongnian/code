    public partial class <#= ViewModelName #>
    {
    <# 
       PushIndent("   "); 
       foreach(var property in ViewModelProperties) {
          if(property.Mapping != null) { 
             WriteLine("[MappedProperty({0})]", property.Mapping);
          }
          WriteLine("public {0} {1} {{ get; set; }}", property.TypeDeclaration, property.MemberName);
       }
       PopIndent(); 
    #>
    }
