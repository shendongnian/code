    <#@ output extension=".cs" #>
    <#@ assembly name="System.Xml" #>
    <#
    var properties = new[]
    {
        "City",
        "State"
    };
    #>
    using System.Runtime.CompilerServices;
    namespace MyNamespace
    {
    <# foreach (var property in properties) { #>
           public string <#= property #>
           {
              get { return _getValue(); }
              set { _setValue(value); }
           }
    <# } #>
           private string _getValue([CallerMemberName] memberName = "")
           {
           }
        
           private void _setValue(object value,
                                  [CallerMemberName] memberName = "")
           {
           }
    }
