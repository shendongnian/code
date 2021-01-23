    /// <summary>
    ///     Represents a bitmap with bit functions.
    /// </summary>
    public class LockedBitmap
    {
	private Rectangle _bounds;
	/// <summary>
	///     Gets or sets the bitmap.
	/// </summary>
	public Bitmap Bitmap { get; set; }
	/// <summary>
	///     Gets or sets the values of the bitmap.
	/// </summary>
	/// <remarks>Watch at the static length!</remarks>
	public uint[] Buffer { get; set; }
	/// <summary>
	///     Gets or sets the bitmap data.
	/// </summary>
	public BitmapData BitmapData { get; set; }
	/// <summary>
	///     Initializes a new instance of <see cref="LockedBitmap" />.
	/// </summary>
	/// <param name="bitmap">The processed bitmap.</param>
	public LockedBitmap(Bitmap bitmap)
	{
		this.Bitmap = bitmap;
	}
	/// <summary>
	///     Locks a Bitmap into system memory.
	/// </summary>
	public unsafe void LockBits()
	{
		var width = this.Bitmap.Width;
		var height = this.Bitmap.Height;
		var imageLockMode = ImageLockMode.UserInputBuffer;
		// Setting imageLockMode
		imageLockMode = imageLockMode | ImageLockMode.ReadOnly;
		imageLockMode = imageLockMode | ImageLockMode.WriteOnly;
		// Save the bouunds
		this._bounds = new Rectangle(0, 0, width, height);
		// Create Pointer
		var someBuffer = new uint[width*height];
		// Pin someBuffer
		fixed (uint* buffer = someBuffer) //pin
		{
			// Create new bitmap data.
			var temporaryData = new BitmapData
			{
				Width = width,
				Height = height,
				PixelFormat = PixelFormat.Format32bppArgb,
				Stride = width*4,
				Scan0 = (IntPtr) buffer
			};
			// Get the data
			this.BitmapData = this.Bitmap.LockBits(this._bounds, imageLockMode, PixelFormat.Format32bppArgb,
				temporaryData);
			// Set values
			this.Buffer = someBuffer;
		}
	}
	/// <summary>
	///     Unlocks this Bitmap from system memory.
	/// </summary>
	public void UnlockBits()
	{
		this.Bitmap.UnlockBits(this.BitmapData);
	}
	/// <summary>
	///     Iterate through all pixel values.
	/// </summary>
	public unsafe void Iterate()
	{
		// Dimension
		var width = this.Bitmap.Width;
		var height = this.Bitmap.Height;
		// Actual uint position
		int cp = 0;
		// Pointer at the fist uint
		var scp = (uint*)this.BitmapData.Scan0;
		// Stick the array
		fixed (uint* cb = this.Buffer)
			// Step through each pixel
			for (uint* cbp = cb, cbdest = cb + this.Buffer.Length; cbp < cbdest; cbp++)
			{
				// Get x and y from position
				var x = cp % width;
				var y = cp / width;
				var color = *cbp;
				
				cp++;  // Increment cp
			}
	}
    }
