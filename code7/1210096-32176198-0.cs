    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                Assembly.GetEntryAssembly().GetManifestResourceNames()));
            Assembly assembly = Assembly.GetEntryAssembly();
            string exeDirectory = Path.GetDirectoryName(assembly.Location);
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                string fileName = _GetFileNameFromResourceName(resourceName),
                    directory = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (Stream outputStream =
                    File.OpenWrite(Path.Combine(exeDirectory, fileName)))
                {
                    assembly.GetManifestResourceStream(resourceName).CopyTo(outputStream);
                }
            }
        }
        private static string _GetFileNameFromResourceName(string resourceName)
        {
            // NOTE: this code assumes that all of the file names have exactly one
            // extension separator (i.e. "dot"/"period" character). I.e. all file names
            // do have an extension, and no file name has more than one extension.
            // Directory names may have periods in them, as the compiler will escape these
            // by putting an underscore character after them (a single character
            // after any contiguous sequence of dots). IMPORTANT: the escaping
            // is not very sophisticated; do not create folder names with leading
            // underscores, otherwise the dot separating that folder from the previous
            // one will appear to be just an escaped dot!
            StringBuilder sb = new StringBuilder();
            bool escapeDot = false, haveExtension = false;
            for (int i = resourceName.Length - 1; i >= 0 ; i--)
            {
                if (resourceName[i] == '_')
                {
                    escapeDot = true;
                    continue;
                }
                if (resourceName[i] == '.')
                {
                    if (!escapeDot)
                    {
                        if (haveExtension)
                        {
                            sb.Append('\\');
                            continue;
                        }
                        haveExtension = true;
                    }
                }
                else
                {
                    escapeDot = false;
                }
                sb.Append(resourceName[i]);
            }
            string fileName = Path.GetDirectoryName(sb.ToString());
            fileName = new string(fileName.Reverse().ToArray());
            return fileName;
        }
    }
