    static void ReplaceVirtualInner(MethodInfo methodToReplace, MethodInfo methodToInject)
    {
        unsafe
        {
            UInt64* methodDesc = (UInt64*)(methodToReplace.MethodHandle.Value.ToPointer());
            int index = (int)(((*methodDesc) >> 32) & 0xFF);
            if (IntPtr.Size == 4)
            {
                uint* classStart = (uint*)methodToReplace.DeclaringType.TypeHandle.Value.ToPointer();
                classStart += 10;
                classStart = (uint*)*classStart;
                uint* tar = classStart + index;
    
                uint* inj = (uint*)methodToInject.MethodHandle.Value.ToPointer() + 2;
                //int* tar = (int*)methodToReplace.MethodHandle.Value.ToPointer() + 2;
                *tar = *inj;
            }
            else
            {
                ulong* classStart = (ulong*)methodToReplace.DeclaringType.TypeHandle.Value.ToPointer();
                classStart += 10;
                classStart = (ulong*)*classStart;
                ulong* tar = classStart + index;
                
                ulong* inj = (ulong*)methodToInject.MethodHandle.Value.ToPointer() + 1;
                //ulong* tar = (ulong*)methodToReplace.MethodHandle.Value.ToPointer() + 1;
                *tar = *inj;
            }
        }
    }
