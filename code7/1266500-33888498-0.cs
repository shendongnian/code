        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = keyData & Keys.KeyCode;
            bool contrloIsPressed = (keyData & Keys.Control) == Keys.Control ? true : false;
            switch (key)
            {
                case Keys.S:
                    if (contrloIsPressed)
                        Save();
                    break;
                case Keys.E:
                    if (contrloIsPressed)
                        Edit();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
