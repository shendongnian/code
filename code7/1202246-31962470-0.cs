    <#@ template language="C#" #>
    <#@ output extension=".gen.cs" #>
    using System;
    namespace SomeNamespace
    {
      public partial struct BambooSounds
      {
      <#foreach(var type in new []{"Bamboo", "Wood", "Metal", "Whatever"};){#>
        public string <#=type#>Animation(<#=type#> animation)
        {
          // Implementation
        }
        public AudioClip <#=type#>Sound(<#=type#> sound)
        {
          // Implementation
        }
        public void ThisMethodOverloadsToShowThatCanBeDoneToo(<#=type#> thing)
        {
          // Implementation
        }
      <#}#>
      }
    }
