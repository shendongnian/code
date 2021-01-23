    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {        
        // This will generate the default constructor    
        public <#=code.Escape(container)#>()
            : base("name=<#=container.Name#>")
        {
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
    #>
            this.Configuration.LazyLoadingEnabled = false;
    <#
    }
    #>
        }
        // Removed this part for readability
    }
