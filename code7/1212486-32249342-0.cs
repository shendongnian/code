    public static bool HandleProcessCmdKey(this IPAMålepunktGui guiMålepunkt, Keys keyData)
            {
                switch (keyData)
                {
                    case Keys.Right:
                    case Keys.Right | Keys.Shift:
                    case Keys.Enter:
                        // go to next field
                        return guiMålepunkt.NæsteFelt();
                    case Keys.Left:
                    case Keys.Left | Keys.Shift:
                        // go to previous field
                        return guiMålepunkt.ForrigeFelt();
                    case Keys.Down:
                    case Keys.Down | Keys.Shift:
                    case Keys.Up:
                    case Keys.Up | Keys.Shift:
                        // disable native navigation
                        return true;
                    case Keys.Tab:
                    case Keys.Tab | Keys.Control:
                        // go to next point
                        return guiMålepunkt.NæsteMålepunkt();
                    case Keys.Tab | Keys.Shift:
                    case Keys.Tab | Keys.Shift | Keys.Control:
                        // go to previous point
                        return guiMålepunkt.ForrigeMålepunkt();
                }
                return false;
            }
