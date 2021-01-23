        protected virtual void Activate() {
            var activeDocument = Inspector.WordEditor as Document;
            if (activeDocument == null)
                return;
            var mailZoom = GetSetting("MailZoom", 125);
            if (mailZoom != 0)
                activeDocument.Windows[1].View.Zoom.Percentage = mailZoom;
            if (GetSetting("MailBlack", true)) {
                activeDocument.Background.Fill.ForeColor.RGB = 0;
                activeDocument.Background.Fill.Visible = msoTrue;
                activeDocument.Saved = true;
            }
        }
