    public static class Extensions {
        public static A GetA(this A me) 
        {
            if (me == null) throw new ArgumentNullException();
            return new A { 
                ContainerName = me.SourceContainer, 
                FolderName = me.SourceContainerFolderName
            };
        }
    }
