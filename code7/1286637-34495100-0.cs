        private readonly OutlookApplication _outlook;
        private readonly NameSpace _mapi;
        private MAPIFolder _baseFolder;
        public EmailMessageProvider()
        {
            _outlook = new OutlookApplication();
            _mapi = _outlook.GetNamespace("MAPI");
            _baseFolder = _mapi.Folders["robert@defaultEmail.com"];
        }
