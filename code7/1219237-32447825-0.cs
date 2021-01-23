     public void OpenForm(string formName)
        {
            switch (formName)
            {
                case "DepoMainForm":
                    DisposeForms();
                    DepoMainForm DepoMainForm = new DepoMainForm
                    {
                        TopLevel = false,
                        Dock = DockStyle.Fill,
                        Parent = _tabDeposito,
                        Visible = true,
                        FormBorderStyle = FormBorderStyle.None
                    };
                    this._tabDeposito.Controls.Add(DepoMainForm);
                    var presenter = new DepoMainPresenter(DepoMainForm);
                    presenter.Init();
                    
                    break;
            }
            
        }
        public void DisposeForms()
        {
            List<Form> toBeDisposed = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if(form.Tag != null && form.Tag.ToString() != "MainForm")
                toBeDisposed.Add(form);
            }
            foreach (Form form in toBeDisposed)
            {
                form.Dispose();
            }
        }
