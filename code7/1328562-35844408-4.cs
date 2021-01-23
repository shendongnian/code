    public class RollingTextWriterTraceListener : TextWriterTraceListener {
        string fileName;
        private static string[] _supportedAttributes = new string[] 
            { 
                "template", "Template", 
                "convertWriteToEvent", "ConvertWriteToEvent",
                "addtoarchive","addToArchive","AddToArchive",
            };
        public RollingTextWriterTraceListener(string fileName)
            : base() {
            this.fileName = fileName;
        }
        /// <summary>
        /// This makes sure that the writer exists to be written to.
        /// </summary>
        private void ensureWriter() {
            //Resolve file name given. relative paths (if present) are resolved to full paths.
            // Also allows for paths like this: initializeData="~/Logs/{ApplicationName}_{DateTime:yyyy-MM-dd}.log"
            var logFileFullPath = ServerPathUtility.ResolvePhysicalPath(fileName);
            var writer = base.Writer;
            if (writer == null && createWriter(logFileFullPath)) {
                writer = base.Writer;
            }
            if (!File.Exists(logFileFullPath)) {
                if (writer != null) {
                    try {
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    } catch (ObjectDisposedException) { }
                }
                createWriter(logFileFullPath);
            }
            //Custom code to package the previous log file(s) into a zip file.
            if (AddToArchive) {
                TextFileArchiveHelper.Archive(logFileFullPath);
            }
        }
        bool createWriter(string logFileFullPath) {
            try {
                logFileFullPath = ServerPathUtility.ResolveOrCreatePath(logFileFullPath);
                var writer = new StreamWriter(logFileFullPath, true);
                base.Writer = writer;
                return true;
            } catch (IOException) {
                //locked as already in use
                return false;
            } catch (UnauthorizedAccessException) {
                //ERROR_ACCESS_DENIED, mostly ACL issues
                return false;
            }
        }
        /// <summary>
        /// Get the add to archive flag
        /// </summary>
        public bool AddToArchive {
            get {
                // Default behaviour is not to add to archive.
                var addToArchive = false;
                var key = Attributes.Keys.Cast<string>().
                    FirstOrDefault(s => string.Equals(s, "addtoarchive", StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrWhiteSpace(key)) {
                    bool.TryParse(Attributes[key], out addToArchive);
                }
                return addToArchive;
            }
        }
        #region Overrides
        /// <summary>
        /// Allowed attributes for this trace listener.
        /// </summary>
        protected override string[] GetSupportedAttributes() {
            return _supportedAttributes;
        }
        public override void Flush() {
            ensureWriter();
            base.Flush();
        }
        public override void Write(string message) {
            ensureWriter();
            base.Write(message);
        }
        public override void WriteLine(string message) {
            ensureWriter();
            base.WriteLine(message);
        }
        #endregion
    }
