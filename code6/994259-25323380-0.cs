    using CSScriptLibrary;
    using csscript;
    using System.CodeDom.Compiler;
    using System.Reflection;
        //Method example - variable script contains cs code
        //This is used to compile cs to DLL and save DLL to a defined location
        public Assembly GetAssembly(string script, string assemblyFileName)
        {
            Assembly assembly;
            CSScript.CacheEnabled = true;            
            try
            {
                bool debugBuild = false;
    #if DEBUG
                debugBuild = true;
    #endif
                if (assemblyFileName == null)
                    assembly = CSScript.LoadCode(script, null);
                else
                    assembly = CSScript.LoadCode(script, assemblyFileName, debugBuild, null);
                return assembly;
            }
            catch (CompilerException e)
            {
                //Handle compiler exceptions
            }
        }
        /// <summary>
        /// Runs the code either form script text or precompiled DLL
        /// </summary>
        public void Run(string script)
        {
            try
            {
                string tmpPath = GetPathToDLLs();  //Path, where you store precompiled DLLs
                string assemblyFileName;
                Assembly assembly = null;
                if (Directory.Exists(tmpPath))
                {
                    assemblyFileName = Path.Combine(tmpPath, GetExamScriptFileName(exam));
                    if (File.Exists(assemblyFileName))
                    {
                        try
                        {
                            assembly = Assembly.LoadFrom(assemblyFileName); //Načtení bez kompilace
                        }
                        catch (Exception exAssemblyLoad)
                        {
                            Tools.LogError(exAssemblyLoad.Message);
                            assembly = null;
                        }
                    }
                }
                else
                    assemblyFileName = null;
                //If assembly not found, compile it form script string
                if (assembly ==null) 
                    assembly = GetAssembly(script, assemblyFileName);
                AsmHelper asmHelper = new AsmHelper(assembly);
                //This is how I use the compiled assembly - it depends on your actual code
                ICalculateScript calcScript = (ICalculateScript)asmHelper.CreateObject(GetExamScriptClassName(exam));
                cex = calcScript.Calculate(this, exam);
                Debug.Print("***** Calculated {0} ****", exam.ZV.ZkouskaVzorkuID);
            }
            catch (Exception e)
            {
                //handle exceptions
            }
        }
