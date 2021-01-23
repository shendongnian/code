    // EDMAURER If defining a string constant and it is too long (length limit is undocumented), this method throws
    // an ArgumentException.
    // (see EMITTER::EmitDebugLocalConst)
    try
    {
        this.symWriter.DefineConstant2(name, value, constantSignatureToken);
    }
    catch (ArgumentException)
    {
        // writing the constant value into the PDB failed because the string value was most probably too long.
        // We will report a warning for this issue and continue writing the PDB.
        // The effect on the debug experience is that the symbol for the constant will not be shown in the local
        // window of the debugger. Nor will the user be able to bind to it in expressions in the EE.
        //The triage team has deemed this new warning undesirable. The effects are not significant. The warning
        //is showing up in the DevDiv build more often than expected. We never warned on it before and nobody cared.
        //The proposed warning is not actionable with no source location.
    }
    catch (Exception ex)
    {
        throw new PdbWritingException(ex);
    }
