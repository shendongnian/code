    public void SetSelectionLineSpacing(byte bLineSpacingRule, int dyLineSpacing)
    {
        PARAFORMAT2 format = new PARAFORMAT2();
        format.cbSize = Marshal.SizeOf(format);
        format.dwMask = PFM_LINESPACING;
        format.dyLineSpacing = dyLineSpacing;
        format.bLineSpacingRule = bLineSpacingRule;
        SendMessage(this.Handle, EM_SETPARAFORMAT, SCF_SELECTION, ref format);
    }
