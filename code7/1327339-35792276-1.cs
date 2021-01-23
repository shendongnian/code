    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct PARTITION_INFORMATION_GPT
    {
        /// <summary>
        /// A GUID that identifies the partition type.
        /// 
        /// Each partition type that the EFI specification supports is identified by its own GUID, which is 
        /// published by the developer of the partition.
        /// </summary>
        [FieldOffset(0)]
        public Guid PartitionType;
    
        /// <summary>
        /// The GUID of the partition.
        /// </summary>
        [FieldOffset(16)]
        public Guid PartitionId;
    
        /// <summary>
        /// The Extensible Firmware Interface (EFI) attributes of the partition.
        /// 
        /// </summary>
        [FieldOffset(32)]
        public UInt64 Attributes;
    
        /// <summary>
        /// A wide-character string that describes the partition.
        /// </summary>
        [FieldOffset(40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Name;
    }
