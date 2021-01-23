    /// <summary>
    ///   Returns a managed reference ("interior pointer") to field 'fi' of type 'U' in
    ///   managed object instance 'obj'
    /// </summary>
	public static unsafe ref U RefFieldValue<U>(Object obj, FieldInfo fi)
	{
		var pobj = Unsafe.As<Object, IntPtr>(ref obj);
		pobj += IntPtr.Size + GetFieldOffset(fi.FieldHandle);
		return ref Unsafe.AsRef<U>(pobj.ToPointer());
	}
