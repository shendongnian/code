        /// <summary>
        /// Writes the JSON value delimiter.  (Remove this override if you want to retain the comma separator.)
        /// </summary>
        protected override void WriteValueDelimiter()
        {
            if (WriteState == WriteState.Array)
                _writer.Write(',');
            else
                _writer.Write(' ');
        }
