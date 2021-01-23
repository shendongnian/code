    /// <summary>
    /// Returns a managed reference ("interior pointer") to the value or instance of type 'U'
    /// stored in the field indicated by 'fi' within managed object instance 'obj'
    /// </summary>
	public static unsafe ref U RefFieldValue<U>(Object obj, FieldInfo fi)
	{
		var pobj = Unsafe.As<Object, IntPtr>(ref obj);
		pobj += IntPtr.Size + GetFieldOffset(fi.FieldHandle);
		return ref Unsafe.AsRef<U>(pobj.ToPointer());
	}
