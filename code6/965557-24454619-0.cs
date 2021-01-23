    char* pMemoryBuffer = NULL;
    int size = 0;
    int seek = 0;
    bool LoadData(const char* filename)
    {
         // load filename
         // set seek = 0
         // set size to data size
    }
    int ReadData(char* buffer, int nBytesToRead)
    {
        // nCopyBytes = min(nBytesToRead, size - seek)
        // copy nCopyBytes from pMemoryBuffer+seek to buffer
        // seek += nCopyBytes
        // return nCopyBytes
    }
