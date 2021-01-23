            void SendUserInfo(tblUser obj) {
            if (obj != null) {
                Messenger.Default.Send<MessageCommunicator>(new MessageCommunicator() { Emp = obj, LeMode=mode.Emp });
            }
        }
        void ReceiveInfo() {
            Messenger.Default.Register<MessageCommunicator>(this, (obj) => {
                if (obj.LeMode == mode.Emp) {
                    this.UsrInfo = obj.Emp; // Stocke l'objet.
                    CloneUser(); // Mémorise pour l'éventuel Undo.
                } else if (obj.LeMode == mode.Grp) { 
                    this.GrpInfo = obj.Grp;
                    CloneGrp();
                }
                leMode = Mode.Edit;
            });
        }
