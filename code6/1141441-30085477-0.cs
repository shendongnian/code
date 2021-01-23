    #define NO_OF_ITERATIONS   100000
    int iteration;
    DWORD tStart;
    SYSTEMTIME tSys;
    FILETIME tFile;
    HANDLE hFile;
    DWORD tEllapsed;
    iteration = NO_OF_ITERATIONS;
    GetLocalTime(&tSys);
    tStart = GetTickCount();
    while (iteration)
    {
       tSys.wYear++;
       if (tSys.wYear > 2020)
       {
          tSys.wYear = 2000;
       }
       SystemTimeToFileTime(&tSys, &tFile);
       hFile = CreateFile("test.dat",
                          GENERIC_WRITE,   // FILE_WRITE_ATTRIBUTES
                          0,
                          NULL,
                          OPEN_EXISTING,
                          FILE_ATTRIBUTE_NORMAL,
                          NULL);
       if (hFile == INVALID_HANDLE_VALUE)
       {
          printf("CreateFile(..) failed (error: %d)\n", GetLastError());
          break;
       }
       SetFileTime(hFile, &tFile, &tFile, &tFile);
       CloseHandle(hFile);
       iteration--;
    }
    tEllapsed = GetTickCount() - tStart;
