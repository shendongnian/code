        private IEnumerable<ErrorDetails> GetErrorDetails(Exception ex)
        {
            for (var scan = ex; scan != null; scan = scan.InnerException)
            {
                var stackTrace = ex.StackTrace;
                yield return new ErrorDetails
                {
                    Error = scan,
                    StackFrames = StackTraceHelper.GetFrames(ex)
                        .Select(frame => GetStackFrame(frame.MethodDisplayInfo.ToString(), frame.FilePath, frame.LineNumber))
                };
            };
        }
        // make it internal to enable unit testing
        internal StackFrame GetStackFrame(string method, string filePath, int lineNumber)
        {
            var stackFrame = new StackFrame
            {
                Function = method,
                File = filePath,
                Line = lineNumber
            };
            if (string.IsNullOrEmpty(stackFrame.File))
            {
                return stackFrame;
            }
            IEnumerable<string> lines = null;
            if (File.Exists(stackFrame.File))
            {
                lines = File.ReadLines(stackFrame.File);
            }
            else
            {
                // Handle relative paths and embedded files
                var fileInfo = _fileProvider.GetFileInfo(stackFrame.File);
                if (fileInfo.Exists)
                {
                    // ReadLines doesn't accept a stream. Use ReadLines as its more efficient
                    // relative to reading lines via stream reader
                    if (!string.IsNullOrEmpty(fileInfo.PhysicalPath))
                    {
                        lines = File.ReadLines(fileInfo.PhysicalPath);
                    }
                    else
                    {
                        lines = ReadLines(fileInfo);
                    }
                }
            }
            if (lines != null)
            {
                ReadFrameContent(stackFrame, lines, stackFrame.Line, stackFrame.Line);
            }
            return stackFrame;
        }
