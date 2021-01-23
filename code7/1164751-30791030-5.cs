    <#@ output extension=".cs" #>
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
        public class Abc
        {
    <# foreach (var property in properties) { #>
            public string <#= property #>
            {
                get { return _getValue(); }
                set { _setValue(value); }
            }
    <# } #>
            private string _getValue([CallerMemberName] memberName = "") {}
            private void _setValue(string value, [CallerMemberName] memberName = "") {}
        }
    }
