            public void switch_keyboard(string lang)
        {
            string keyboard_lang = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;
            if (keyboard_lang != lang) 
            {
                int en_index = -1;
                for (int i = 0; i < System.Windows.Forms.InputLanguage.InstalledInputLanguages.Count - 1; i++)
                {
                    try  
                    {
                        if (System.Windows.Forms.InputLanguage.InstalledInputLanguages[i].Culture.TwoLetterISOLanguageName == lang)
                        { en_index = i;  break; }
                    }
                    catch { break; }
                }
                if (en_index != -1)
                { InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.InstalledInputLanguages[en_index]; }
            }
        }
