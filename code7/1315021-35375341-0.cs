    // possibly use a backing field for all controls to evaluate
    private readonly Control[] textBoxes = new[] { textBoxFirstName, textBoxLastName };
    // helper property to evaluate the controls
    private bool HasErrors 
    { 
        get { return textBoxes.Any(x => !string.IsNullOrEmpty(errorProvider.GetError(x)); }
    }
