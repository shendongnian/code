            private void LoadFontFromResourcesByName(string FontName)
            {
                using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(FontName))
                {
                    System.IntPtr data = System.IntPtr.Zero;
                    try
                    {
                        data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                        byte[] fontdata = new byte[fontStream.Length];
                        fontStream.Read(fontdata, 0, (int)fontStream.Length);
                        Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                        LoadFont.AddMemoryFont(data, (int)fontStream.Length);
                    }
                    finally
                    {
                        if (data != System.IntPtr.Zero)
                            Marshal.FreeCoTaskMem(data);
                    }
                }
            }
