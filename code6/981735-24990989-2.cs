    <#@ template language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Diagnostics" #>
    
    <#+
    public class ClassDefinition
    {
        public string NameSpace { get; set; }
        public string Name { get; set; }
        public string Protection { get; set; }
    
        List<ClassProperty> Properties { get; set; }
    }
    #>
