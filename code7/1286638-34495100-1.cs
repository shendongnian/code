        public void MoveSpecificEmailsToArchives()
        {
            var destination = _mapi.Folders["Archives"];
            foreach (var mailItem in _baseFolder.Folders["Unexpected Error"].Items.OfType<MailItem>())
            {
                mailItem.UseMailItem(x =>
                {
                    if (x.Body.Contains("offensiveProgram.exe ERROR "))
                        x.Move(destination);
                });
            }
            Release(destination);
        }
