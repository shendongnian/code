    [BaseType (typeof (NSObject),Name = "MITIntegration"]
    public partial interface MITIntegration {
        [Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
        MITIntegrationDelegate Delegate { get; set; }
  
        // ...
    }
