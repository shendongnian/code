    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {
        public <#=code.Escape(container)#>()
            : base("name=<#=container.Name#>")
        {
    	   // Timeout setting
    	   ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300; 
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
