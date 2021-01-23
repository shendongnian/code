    // get/set both public
    public string Name { get; set; }
     
    // get/set both private
    private string SecretName { get; set; }
     
    // public get => read-only
    public string CalcName { get; private set; }
     
    // public set => write-only
    public string WriteOnlyName { private get; set; }
