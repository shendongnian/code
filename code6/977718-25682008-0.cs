    /// <summary>
	/// Contract for PrintCapabilities
	/// </summary>
	public interface IPrintCapabilities
	{
		/// <summary>
		/// Gets CollactionCapability.
		/// </summary>
		IEnumerable<Collation> CollationCapability { get; }
		
		/// <summary>
		/// Gets MaxCopyCount.
		/// </summary>
		int? MaxCopyCount { get; }
		/// <summary>
		/// Gets OrientedPageMediaHeight.
		/// </summary>
		double? OrientedPageMediaHeight { get; }
		/// <summary>
		/// Gets OrientedPageMediaWidth.
		/// </summary>
		double? OrientedPageMediaWidth { get; }
		/// <summary>
		/// Gets PageMediaSizeCapability.
		/// </summary>
		IEnumerable<PageMediaSize> PageMediaSizeCapability { get; }
		/// <summary>
		/// Gets PageOrientationCapability.
		/// </summary>
		IEnumerable<PageOrientation> PageOrientationCapability { get; }
		/// <summary>
		/// Gets DuplexingCapability.
		/// </summary>
		IEnumerable<Duplexing> DuplexingCapability { get; }
		/// <summary>
		/// Gets InputBinCapability.
		/// </summary>
		IEnumerable<InputBin> InputBinCapability { get; }
		/// <summary>
		/// Gets OutputColorCapability.
		/// </summary>
		IEnumerable<OutputColor> OutputColorCapability { get; }
		/// <summary>
		/// Gets PageOrderCapability.
		/// </summary>
		IEnumerable<PageOrder> PageOrderCapability { get; }
		/// <summary>
		/// Gets StaplingCapability.
		/// </summary>
		IEnumerable<Stapling> StaplingCapability { get; }
	}
    
	/// <summary>
	/// Contract for PrintQueue
	/// </summary>
	public interface IPrintQueue
	{
		/// <summary>
		/// Gets IsOffline flag.
		/// </summary>
		bool IsOffline { get; }
		/// <summary>
		/// Gets FullName.
		/// </summary>
		string FullName { get; }
		/// <summary>
		/// Refreshes PrintQueue.
		/// </summary>
		void Refresh();
		/// <summary>
		/// Gets or sets DefaultPrintTicket.
		/// </summary>
		IPrintTicket DefaultPrintTicket { get; set; }
		/// <summary>
		/// Gets PrintCapabilities.
		/// </summary>
		/// <returns></returns>
		IPrintCapabilities GetPrintCapabilities();
	}
    
	/// <summary>
	/// Contract for PrintQueueCollection.
	/// </summary>
	public interface IPrintQueueCollection : IEnumerable
	{
	}
    
	/// <summary>
	/// Interface that describes all classes implementing PrintServer operations.
	/// </summary>
	public interface IPrintServer
	{
		/// <summary>
		/// Gets the collection of print queues of the specific types.
		/// </summary>
		/// <param name="enumerationFlag">Array of types of print queues.</param>
		/// <returns>Print queues collection.</returns>
		IPrintQueueCollection GetPrintQueues(EnumeratedPrintQueueTypes[] enumerationFlag);
		
		/// <summary>
		/// Returns a reference of default print queue of LocalPrintServer.
		/// </summary>
		/// <returns>Print queue.</returns>
		IPrintQueue GetDefaultPrintQueue();
	}
    
	/// <summary>
	/// Contract for PrintTicket
	/// </summary>
	public interface IPrintTicket
	{
		/// <summary>
		/// Gets or sets PageOrientation.
		/// </summary>
		PageOrientation? PageOrientation { get; set; }
		
		/// <summary>
		/// Gets or sets Duplexing.
		/// </summary>
		Duplexing? Duplexing { get; set; }
		
		/// <summary>
		/// Gets or sets Stapling.
		/// </summary>
		Stapling? Stapling { get; set; }
		
		/// <summary>
		/// Gets or sets PageOrder.
		/// </summary>
		PageOrder? PageOrder { get; set; }
		
		/// <summary>
		/// Gets or sets OutputColor.
		/// </summary>
		OutputColor? OutputColor { get; set; }
		
		/// <summary>
		/// Gets or sets Collation.
		/// </summary>
		Collation? Collation { get; set; }
		/// <summary>
		/// Gets or sets PageMediaSize.
		/// </summary>
		PageMediaSize PageMediaSize { get; set; }
	}
