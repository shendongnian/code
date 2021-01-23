    public static A GetA(this B baseB)
    {
    	return new A
        {
    		ContainerName = baseB.SourceContainer,
    		FolderName = baseB.SourceContainerFolderName,
    	};
    }
