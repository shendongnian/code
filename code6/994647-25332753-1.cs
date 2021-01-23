                if (wkbk != null)
                {
                    try
                    {
                        wkbk.Close(false);
                    }
                    catch
                    {
                    }
                    Marshal.FinalReleaseComObject(wkbk);
                    wkbk = null;
                }
