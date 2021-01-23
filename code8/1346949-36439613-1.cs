    class Program
    {
        //Deploys the DLL to the location of the executable, as suggested by B. Clay Shannon
        //The Program() method runs before Main() and allows for regisration or placement
        //of files before the program "starts". Placing this line in Main()
        //causes a FileNotFound exception when it tries to register the assembly.
        static Program()
        {
            //The dll has been added as a resource, build action "Content".
            //Note the underscores in "Microsoft_Win32_TaskScheduler"
            //Adding the dll to the resource manager replaces '.' with '_' in the resource name
            File.WriteAllBytes(string.Format("{0}{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\Microsoft.Win32.TaskScheduler.dll"), FindResourceByName("Microsoft_Win32_TaskScheduler"));
        }
            
        static void Main(string[] args)
        {
            ...
        }
        /// <summary>
        ///   Returns a byte array of the object searched for
        /// </summary>
        /// <param name="objectName">Name of the resource object</param>
        /// <returns>Byte array of the specified resource object</returns>
        private static byte[] FindResourceByName(string objectName)
        {
            object obj = Properties.Resources.ResourceManager.GetObject(objectName);
            return ((byte[])(obj));
        }
    }
