    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {        
        // This will generate the default constructor    
        public <#=code.Escape(container)#>()
            : this("name=<#=container.Name#>")
        {
        }
        // This is the overload you need
        public <#=code.Escape(container)#>(string nameOrConnectionString)
            : base(nameOrConnectionString)
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
