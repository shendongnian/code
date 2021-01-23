    #>
    public <#=code.Escape(entity)#>()
    {
    <#
        //default T4 logic that was processing properties
    #>
		OnConstructorConpletion();
    }
	
	partial void OnConstructorConpletion();
    <#
