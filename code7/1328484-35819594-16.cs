		public static class KeyBoardInput
		{
			public enum VmKeyScanState : byte
			{
				SHIFT = 1,
				CTRL = 2, ...
			}			
			
			public enum VirtualKeyCode : byte
			{
				...
			}
			
			[StructLayout(LayoutKind.Explicit)]
			public struct VmKeyScanResult
			{
				[FieldOffset(0)]
				private VirtualKeyCode _virtualKey;
				[FieldOffset(1)]
				private VmKeyScanState _scanState;
				
				public VirtualKeyCode VirtualKey
				{
					get {return this._virtualKey}
				}
				public VmKeyScanState ScanState
				{
					get {return this._scanState;}
				}
				
				public Boolean IsFailure
				{
					get
					{
						return 
							(this._scanState == 0xFF) &&
							(this._virtualKey == 0xFF)
					}					
				}
			}
			
			[DllImport(DllNames.User32, CharSet=CharSet.Unicode, EntryPoint="VmKeyScan")]
			private static extern VmKeyScanResult VmKeyScanNative(Char ch);
			public static VmKeyScanResult TryVmKeyScan(Char ch)
			{
				return VmKeyScanNative(ch);
			}
			public static VmKeyScanResult VmKeyScan(Char ch)
			{
				var result = VmKeyScanNative(ch);	
				if (result.IsFailure)
					throw new InvalidOperationException(
						String.Format(
							"Failed to VmKeyScan the '{0}' char",
							ch));
				return result;
			}
		}
