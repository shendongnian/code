    private void build_string<T>() where T : struct
    {
        try
        {
            T[] mData = new T[1000];
            Marshal.Copy(myPointer,(dynamic) mData, 0, 1000);
            descriptor_string.Append(String.Join(", ", mData.Select(item=>item.ToString()));
        } 
        catch(RuntimeBinderException rbe)
        {
            // Handle case here where there is no suitable Marshal.Copy Method.
        }
    }
