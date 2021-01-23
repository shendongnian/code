    class Program
    {
        //Programmatically, the Program() method is called prior to Main() and before any registrations are made.
        //This is where we write the dll to the disk.
        static Program()
        {
            //Path.GetDirectoryName() returns the folder path to a particular file.
            //Assembly.GetExecutingAssembly().Location returns the path to the current running location of the compiled executable, with the name. E.G. C:\MyProject\MyProgram.exe
            //We combine this with Path.GetDirectoryName to get the folder, and then write the dll into this folder. That way, when this method finishes and main is called, it will find the dll in the folder.
            File.WriteAllBytes(string.Format("{0}{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\log4net.dll"), FindResourceByName("log4net"));
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
        //Rest of your code goes here...
    }
