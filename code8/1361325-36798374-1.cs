        public DataTable GetDotNetAssemblies(string baseDirectory)
        {
            DataTable MethodResult = null;
            try
            {
                if (Directory.Exists(baseDirectory))
                {
                    List<string> FilePaths = NetworkConnection.GetAllFilesUnderDirectory(baseDirectory);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Directory");
                    dt.Columns.Add("Filename");
                    dt.Columns.Add("Date modified");
                    dt.Columns.Add("Bytes");
                    dt.Columns.Add("User modified");
                    foreach (string FilePath in FilePaths)
                    {
                        DataRow dr = dt.NewRow();
                        FileInfo f = new FileInfo(FilePath);
                        List<string> AllowedExtensions = new List<string>();
                        AllowedExtensions.Add(".exe");
                        AllowedExtensions.Add(".dll");
                        bool IsDotNetAssembly = false;
                        try
                        {
                            AssemblyName a = AssemblyName.GetAssemblyName(FilePath);
                            
                            IsDotNetAssembly = true;
                        } catch {}
                        if (AllowedExtensions.Contains(f.Extension.ToLower()) && IsDotNetAssembly)
                        {
                            dr["Directory"] = f.Directory;
                            dr["Filename"] = f.Name;
                            dr["Date modified"] = f.LastWriteTime;
                            dr["Bytes"] = f.Length.ToString();
                            string UserModified = "";
                            try
                            {
                                UserModified = f.GetAccessControl().GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                            }
                            catch
                            {
                                UserModified = "Unknown";
                            }
                            dr["User modified"] = UserModified;
                            dt.Rows.Add(dr);
                        }
                    }
                    dt.AcceptChanges();
                    MethodResult = dt;
                }
                else
                {
                    MessageBox.Show("Unable to connect to directory:\n" + baseDirectory);
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
