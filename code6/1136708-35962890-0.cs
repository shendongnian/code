      private void contextSuperEditor_Opening(object sender, CancelEventArgs e)
            {
                if (tbText.SelectionLength > 0)
                {
                    MenuCopy.Enabled = true;
                    MenuCut.Enabled = true;
                    MenuPaste.Enabled = false; 
                }
                else
                {
                    MenuCopy.Enabled = false;
                    MenuCut.Enabled = false;
                    if (Clipboard.ContainsText() | Clipboard.ContainsImage())
                    {
                        MenuPaste.Enabled = true;
                    }
                }
            }
