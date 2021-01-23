    public partial class <#= ViewModelName #>
    {
    <#
        foreach(var property in ViewModelProperties) { 
            if(property.Mapping != null) { 
    #>
        [MappedProperty("<#= property.Mapping #>")]
    <#
            }
    #>
        public <#= property.TypeDeclaration #> <#= property.MemberName #> { get; set; }
    <#
        }
    #>
    }
