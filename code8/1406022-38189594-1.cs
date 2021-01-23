    public static class Extensions {
        public static A GetA(this B me) 
        {
            if (me == null) throw new ArgumentNullException();
            return new A { 
                ContainerName = me.SourceContainer, 
                FolderName = me.SourceContainerFolderName
            };
        }
    }
