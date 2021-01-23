	<System.Runtime.CompilerServices.Extension()> _
	Public Sub ZeroFree(ByRef str As String)
		If String.IsInterned(str) IsNot Nothing Then
			Throw New Exception("Interned strings are not supported!")
			Return
		End If
		Dim gch As GCHandle = GCHandle.Alloc(str, GCHandleType.Pinned)
		ZeroMemory(gch.AddrOfPinnedObject, str.Length * 2)
		gch.Free()
        str = Nothing
	End Sub
	Public Sub ZeroMemory(ByVal location As IntPtr, ByVal size As Integer)
		For i As Integer = 0 To size
			Marshal.WriteByte(IntPtr.Add(location, i), 0)
		Next
	End Sub
