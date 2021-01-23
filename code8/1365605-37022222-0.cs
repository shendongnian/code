    private void FindRelatedFiles
    (
        Reference reference
    )
    {
        string baseName = reference.FullPathWithoutExtension;
        // Look for companion files like pdbs and xmls that ride along with 
        // assemblies.
        foreach (string companionExtension in _relatedFileExtensions)
        {
            string companionFile = baseName + companionExtension;
            if (_fileExists(companionFile))
            {
                reference.AddRelatedFileExtension(companionExtension);
            }
        }
        ...
    }
