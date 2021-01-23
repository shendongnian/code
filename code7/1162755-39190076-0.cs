    // To make SCOM SDK calls fast
    [assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
    [assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
    [assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)]
    [assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
    [assembly: PermissionSet(SecurityAction.RequestMinimum, Name = "Execution")]
    [assembly: PermissionSet(SecurityAction.RequestRefuse, Unrestricted = false)]
    [module: UnverifiableCode]
    [assembly: CLSCompliant(false)]
