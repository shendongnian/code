    public static bool Show(params string[] Paths)
    {
        SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
        info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
        info.lpVerb = "properties";
        string Params = "";
        for (int i = 0, Count = Paths.Length; i < Count; i++)
            Params += Paths[i].ToString() + ' ';
        info.lpParameters = Params;
        info.nShow = SW_SHOW;
        info.fMask = SEE_MASK_INVOKEIDLIST;
        return ShellExecuteEx(ref info);
    }
