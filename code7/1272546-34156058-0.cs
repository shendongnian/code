	[StructLayout(LayoutKind.Sequential)]
	public struct GestureInfo
	{
		/// <summary>
		/// Specifies the size of the structure in bytes.  This must be set to Marshal.SizeOf(typeof(GESTUREINFO))
		/// </summary>
		public uint Size;
		/// <summary>
		/// Gesture Flags
		/// </summary>
		public GestureState State;
		/// <summary>
		/// Gesture Id
		/// </summary>
		public GestureKind Kind;
		/// <summary>
		/// HWND of the target winndow
		/// </summary>
		public IntPtr TargetWindow;
		/// <summary>
		/// Coordinates of start of gesture
		/// </summary>
		public short LocationX;
		/// <summary>
		/// Coordinates of start of gesture
		/// </summary>
		public short LocationY;
		/// <summary>
		/// Gesture Instance Id
		/// </summary>
		public uint InstanceId;
		/// <summary>
		/// Gesture Sequence Id
		/// </summary>
		public uint SequenceId;
		/// <summary>
		/// Arguments specific to gesture
		/// </summary>
		public ulong Arguments;
		/// <summary>
		/// Size of extra arguments in bytes
		/// </summary>
		public uint ExtraArguments;
	}
