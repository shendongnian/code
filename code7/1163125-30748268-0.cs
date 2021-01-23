    // Returns the extension of the given path. The returned value includes the
    // period (".") character of the extension except when you have a terminal period when you get String.Empty, such as ".exe" or
    // ".cpp". The returned value is null if the given path is
    // null or if the given path does not include an extension.
    //
    [Pure]
    public static String GetExtension(String path) {
        if (path==null)
            return null;
 
        CheckInvalidPathChars(path);
        int length = path.Length;
        for (int i = length; --i >= 0;) {
            char ch = path[i];
            if (ch == '.')
            {
                if (i != length - 1)
                    return path.Substring(i, length - i);
                else
                    return String.Empty;
            }
            if (ch == DirectorySeparatorChar || ch == AltDirectorySeparatorChar || ch == VolumeSeparatorChar)
                break;
        }
        return String.Empty;
    }
