            try
            {
                string[] allDictionaries = (string[])Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Spelling\Dictionaries", "_Global_",  new string[0]);
                if (allDictionaries.Count() > 0)
                {
                    List<string> realDictionaries = new List<string>();
                    bool changedSomething = false;
                    foreach (string thisD in allDictionaries)
                    {
                        if (File.Exists(thisD))
                        {
                            if (thisD.Contains(@"\AppData\Local\Temp\"))
                            {
                                // Assuming that anyone who wants to keep a permanent .dic file will not store it in \AppData\Local\Temp
                                // So delete the file and don't copy the name of the dictionary into the list of good dictionaries.
                                File.Delete(thisD);
                                changedSomething = true;
                            }
                            else
                            {
                                realDictionaries.Add(thisD);
                            }
                        }
                        else
                        {
                            // File does not exist, so don't copy the name of the dictionary into the list of good dictionaries.
                            changedSomething = true;
                        }
                    }
                    if (changedSomething)
                    {
                        Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Spelling\Dictionaries", "_Global_", realDictionaries.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error clearing up old dictionary files.\n\nFull message:\n\n" + ex.Message, "Unable to delete file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
