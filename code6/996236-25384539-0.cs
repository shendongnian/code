    protected override void Dispose(bool disposing)
    {
        // Dispose of our resources if this StreamReader is closable.
        // Note that Console.In should be left open.
        try {
            // Note that Stream.Close() can potentially throw here. So we need to 
            // ensure cleaning up internal resources, inside the finally block.  
            if (!LeaveOpen && disposing && (stream != null))
                stream.Close();
        }
        finally {
            if (!LeaveOpen && (stream != null)) {
                stream = null;
                encoding = null;
                decoder = null;
                byteBuffer = null;
                charBuffer = null;
                charPos = 0;
                charLen = 0;
                base.Dispose(disposing);
            }
        }
    }
