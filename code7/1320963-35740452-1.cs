		[System.Security.SecurityCritical]  // auto-generated
		[MethodImplAttribute(MethodImplOptions.Synchronized)]
	#if FEATURE_CORRUPTING_EXCEPTIONS
		[HandleProcessCorruptedStateExceptions] 
	#endif // FEATURE_CORRUPTING_EXCEPTIONS
		internal unsafe IntPtr ToAnsiStr(bool allocateFromHeap) {
			EnsureNotDisposed();
			
			IntPtr ptr = IntPtr.Zero;
			IntPtr result = IntPtr.Zero;          
			int byteCount = 0;
			RuntimeHelpers.PrepareConstrainedRegions();                        
			try {
				// GetAnsiByteCount uses the string data, so the calculation must happen after we are decrypted.
				UnProtectMemory();
				
				// allocating an extra char for terminating zero
				byteCount = GetAnsiByteCount() + 1; 
				
				RuntimeHelpers.PrepareConstrainedRegions();
				try {
				}
				finally {
					if( allocateFromHeap) {
						ptr = Marshal.AllocHGlobal(byteCount);
					}
					else {
						ptr = Marshal.AllocCoTaskMem(byteCount);
				   }                    
				}
				if (ptr == IntPtr.Zero) {
					throw new OutOfMemoryException();
				}
				
				GetAnsiBytes((byte *)ptr.ToPointer(), byteCount);
				result = ptr;                
			}
			catch (Exception) {
				ProtectMemory();
				throw;
			}
			finally {
				ProtectMemory();
				if( result == IntPtr.Zero) { 
					// If we failed for any reason, free the new buffer
					if (ptr != IntPtr.Zero) {
						Win32Native.ZeroMemory(ptr, (UIntPtr)byteCount);
						if( allocateFromHeap) {                                                    
							Marshal.FreeHGlobal(ptr);
						}
						else {
							Marshal.FreeCoTaskMem(ptr);                            
						}
					}                    
				}                
				
			}
			return result;
		}
