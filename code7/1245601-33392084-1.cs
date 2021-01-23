	    string versionPrefix = "v_";// Same prefix pattern you need to follow while creating classes
            string strVersion =  1.6.2; // 1.4.1 any
            string dllPath =System.Web.HttpRuntime.BinDirectory; 
            string dllName = "dllName.dll";
            string Version = versionPrefix +  
            string strclassNameWithFullPath = dllPath + Version.Replace(".", "") + "." + className; 
            try
            {
                string strAssemblyWithPath = string.Concat(dllPath, dllName);
                if (!System.IO.File.Exists(strAssemblyWithPath))
                {
                    return null;
                }
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(strAssemblyWithPath);
                Type t = assembly.GetType(strclassNameWithFullPath);
                object obj = Activator.CreateInstance(t);
                return (iTestInterface)obj;
            }
            catch (Exception exc)
            {
                //string errStr = string.Format("Error occured while late assembly binding. dllPath = {0}, dllName = {1}, className = {2}.", dllPath, dllName, className);
                return null;
            }
        }
