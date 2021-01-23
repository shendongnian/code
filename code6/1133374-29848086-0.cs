                FileStream fs = new FileStream("C:\\test.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                    sw.Write(identity.Name);
                }
                catch (Exception ex)
                {
                    sw.Write(ex.Message);
                }
                finally
                {
                    sw.Flush(); sw.Dispose();
                }
