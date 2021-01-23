<#@ template debug="true" hostspecific="false" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Text.RegularExpressions" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ include file="IncludedCSFile.cs" #>
<#@ output extension=".cs" #>
<#
// do stuff
#>
My `IncludedCSFile.cs` looks like this:
// <#+ /*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace MyNamespace
{
// */
    public class MyClass
    {
        // etc...
    }
}
// #>
## Explanation:
// <#+ /*
* The initial `// ` stops the main C# parser (from the project) from seeing the T4 `<#+` delimiter which would cause a project syntax error.
* The `<#+` however *is* parsed by the T4 parser and causes the C# within the file to be interpreted as code that the T4 script can use.
* The `/*` following starts a new comment that causes T4's C# parser to ignore the `using...` statements and opening `namespace MyNamespace` lines which would otherwise cause a T4 syntax error.
    * This is because T4 requires `using` statements to be expressed as `<#@ import namespace="" #>` directives.
// */
* This is the terminating delimiter for the opening block comment behind the first `<#+`.
* The `//` hides the `*/` from the project C# compiler (which doesn't see the `/*`), while T4's C# compiler will see it because the `//` is overridden by the previous `/*`.
  * This works because in C# block-comments will "comment-out" other comments (if that makes sense!).
// #>
* Finally, T4 requires a T4 block terminator before EOF, so we use the same leading-`//` trick to hide it from C# while T4 can still see it.
## Disadvantages:
There are a few downsides to this approach:
* A leading `//` will be rendered to the final output file.
  * I don't believe this can be mitigated.
* The included T4 file cannot declare its own namespace imports.
  * Though this isn't a problem for small T4 scripts where it isn't a problem to ensure they're all added to the entrypoint T4 script.
  * Another workaround is to create an actual `*.ttinclude` file which has only the necessary `<#@ import namespace="" #>` directives and then includes the `*.cs` file.
* The included file cannot be executed as its own T4 file due to a lack of `<#@ template #>` and `<#@ output #>` directives which I understand must be placed at the start of a file.
  * Granted, most included `*.ttinclude` files cannot be executed by themselves anyway.
