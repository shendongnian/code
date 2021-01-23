    // In the UIAppearanceExtensibility project
    [assembly: UI.Aspects.NullableMethodCallAspect(
        AttributeInheritance = MulticastInheritance.Strict
        AttributeTargetTypes = "UI.Appearance.Extensibility.Triage.*",
        AttributeTargetMembers = "regex: handle*"
    )]
