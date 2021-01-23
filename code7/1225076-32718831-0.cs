	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
	{
            EnvDTE.TextSelection ts = DTE.ActiveDocument.Selection as EnvDTE.TextSelection;
            ts.Text = "/* " + ts.Text + " */";
	}
