    ComponentDispatcher.ThreadPreprocessMessage += (ref MSG m, ref bool handled) => {
                //check if WM_KEYDOWN, print some message to test it
                if (m.message == 0x100)
                {
                    System.Diagnostics.Debug.Print("Key down!");
                }
            };
