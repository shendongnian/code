    private void FormHandler_Form1Hide()
        {
           if (InvokeRequired)
            {
                this.Invoke(new Action(
                    () =>
                    {
                        Hide();
                    })
                    );
            }
            else
            {
                Hide();
            }
        }
