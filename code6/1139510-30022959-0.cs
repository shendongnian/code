    public static ptsDTM CreateFromExistingFile(string fileName)
    {
       ptsDTM returnTin = new ptsDTM();
       Task<ptsDTM> tsk = Task.Run(() => loadAsBinaryAsync(fileName));
       returnTin = tsk.Result;  // I suspect the problem is here.
       return retunTin;
    }
