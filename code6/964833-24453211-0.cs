        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            var text = Context.Parameters["ScreensaverPath"];
            var file = new FileInfo(text + "MyScreenSaver.exe");
            if (!file.Exists)
                return;
            file.MoveTo(text + "MyScreenSaver.scr");
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            var text = Context.Parameters["ScreensaverPath"];
            var file = new FileInfo(text + "MyScreenSaver.scr");
            if (!file.Exists)
                return;
            file.MoveTo(text + "MyScreenSaver.exe");
        }
