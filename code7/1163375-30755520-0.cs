    [Parameter]
    public SwitchParameter ShowDefinition { get; set; }
    
    protected override void ProcessRecord(){
        if(ShowDefinition.ToBool()){
        ...
        }
    }
