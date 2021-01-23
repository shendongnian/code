    class DropboxFolderWatchMessageReader : IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(IMessageReader))]
        private List<IMessageReader> readers;
        [System.ComponentModel.Composition.ImportingConstructorAttribute]
        public DropboxFolderWatchMessageReader(IConfig config)
        {
            // empty body. readers still null here
        }
        public void OnImportsSatisfied()
        {
            // old constructor body.
            // it's safe to use readers here as all imports have been satisfied
        }
    }
