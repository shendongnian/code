    public ICommand SaveCommand
            {
                get
                {
                    if (btnSave == null)
                        btnSave = new Save();
    btnSave.Model = this.ClientModel;
    
                    return btnSave;
                }
                set { btnSave = value; }
            }
