    /// <summary>
    ///     This helper allows for easier manipulation of <see cref="Enum" /> objects with the <see cref="FlagsAttribute" />.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms",
    	MessageId = "Flags",
    	Justification = "This struct acts as a wrapper around Enum Flags, and relates to the term in question.")]
    public struct Flags<T> : IEquatable<Flags<T>>, IEquatable<T>
    {
    	#region Fields
    	private T _value;
    	#endregion
    
    	#region Constructors
    	/// <summary>
    	///     This constructor assures that the generic type of <typeparamref name="T" /> is first valid flags enum type.
    	/// </summary>
    	/// <exception cref="ArgumentException">Thrown if the type of <typeparamref name="T" /> is not a valid flag enum type.</exception>
    	[SuppressMessage("Microsoft.Usage", "CA2207:InitializeValueTypeStaticFieldsInline",
    		Justification = "This static constructor is not initializing any field values, instead, it is performing Type validation on the generic type T that cannot be otherwise performed.")]
    	[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
    		MessageId = "DMFirmy.Library.Core.Utilities.Throw.InvalidArgumentIf(System.Boolean,System.String,System.String)",
    		Justification = "This library will not be localized.")]
    	static Flags()
    	{
    		var type = typeof(T);
    		Throw.InvalidArgumentIf(!type.IsEnum, "Flags<T> can only be used with enum types", nameof(T));
    		Throw.InvalidArgumentIf(type.GetCustomAttributes(typeof(FlagsAttribute), false).Length == 0, "Flags<T> can only be used with enum types with the Flags attribute", nameof(T));
    	}
    
    	private Flags(T value)
    	{
    		_value = value;
    	}
    	#endregion
    
    	#region Properties
    	private long ValueInLong
    	{
    		get { return GetLongValue(_value); }
    		set { _value = (T)Enum.ToObject(typeof(T), value); }
    	}
    
    	/// <summary>
    	///		Gets an enumerable collection of each of the individual flags that compose this instance.
    	/// </summary>
    	public IEnumerable<T> AllFlags
    	{
    		get
    		{
    			var values = (T[])Enum.GetValues(typeof(T));
    			// ReSharper disable once LoopCanBeConvertedToQuery
    			foreach (var f in values)
    			{
    				if (this[f]) yield return f;
    			}
    		}
    	}
    	#endregion
    
    	#region Indexers
    	/// <summary>
    	///     This indexer is used to add or check values within the stored flags.
    	/// </summary>
    	/// <param name="flags">The flags to search for.</param>
    	/// <returns>True if the flag is contained, flase otherwise.</returns>
    	[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms",
    		MessageId = "flags",
    		Justification = "This struct is first wrapper around Enum Flags, and relates to the term in question.")]
    	[IndexerName("Item")]
    	public bool this[T flags]
    	{
    		get
    		{
    			var flagsInLong = GetLongValue(flags);
    			return (ValueInLong & flagsInLong) == flagsInLong;
    		}
    		set
    		{
    			var flagsInLong = GetLongValue(flags);
    
    			if(value)
    			{
    				ValueInLong |= flagsInLong;
    			}
    			else
    			{
    				ValueInLong &= ~flagsInLong;
    			}
    		}
    	}
    	#endregion
    
    	#region Methods
    	/// <summary>
    	///     Returns true if the given <paramref name="flags" /> are completely contained.
    	/// </summary>
    	/// <param name="flags">The flags to check that the underlying value contains.</param>
    	/// <returns></returns>
    	[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms",
    		MessageId = "flags",
    		Justification = "This struct is first wrapper around Enum Flags, and relates to the term in question.")]
    	public bool Contains(T flags)
    	{
    		return this[flags];
    	}
    
    	[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms",
    		MessageId = "flags",
    		Justification = "This struct is first wrapper around Enum Flags, and relates to the term in question.")]
    	[SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
    		MessageId = "System.Convert.ToInt64(System.Object)",
    		Justification = "This library will not be localized.")]
    	private static long GetLongValue(T flags)
    	{
    		return Convert.ToInt64(flags);
    	}
    
    	/// <summary>
    	///     Indicates whether this instance and first specified object are equal.
    	/// </summary>
    	/// <param name="obj">Another object to compare to.</param>
    	/// <returns>
    	///     <c>true</c> if <paramref name="obj" /> and this instance are the same type and represent the same value;
    	///     otherwise, <c>false</c>.
    	/// </returns>
    	public override bool Equals(object obj)
    	{
    		// ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
    		if(obj is T)
    		{
    			return Equals((T)obj);
    		}
    
    		if(obj is Flags<T>)
    		{
    			return Equals((Flags<T>)obj);
    		}
    
    		return false;
    	}
    
    	/// <summary>
    	///     Indicates whether the current object is equal to another object of the same type.
    	/// </summary>
    	/// <param name="other">An object to compare with this object.</param>
    	/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
    	public bool Equals(Flags<T> other)
    	{
    		return Equals(other._value);
    	}
    
    	/// <summary>
    	///     Indicates whether the current object is equal to another object of the same type.
    	/// </summary>
    	/// <param name="other">An object to compare with this object.</param>
    	/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
    	public bool Equals(T other)
    	{
    		return Equals(_value, other);
    	}
    
    	/// <summary>
    	///     Returns the hash code for this instance.
    	/// </summary>
    	/// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
    	public override int GetHashCode()
    	{
    		// ReSharper disable once NonReadonlyMemberInGetHashCode
    		return _value.GetHashCode();
    	}
    
    	/// <summary>
    	///     Returns the string representation of the underlying value.
    	/// </summary>
    	/// <returns>The string representation of the underlying value</returns>
    	public override string ToString()
    	{
    		return _value.ToString();
    	}
    	#endregion
    
    	#region Operators
    	/// <summary>
    	///     Implicit conversion from <see cref="Flags{T}" /> to the underlying <typeparamref name="T" /> value.
    	/// </summary>
    	/// <param name="flags">The <see cref="Flags{T}" /> value.</param>
    	/// <returns>
    	///     The <typeparamref name="T" /> value represented by <paramref name="flags" />
    	/// </returns>
    	[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms",
    		MessageId = "flags",
    		Justification = "This struct is first wrapper around Enum Flags, and relates to the term in question.")]
    	public static implicit operator T(Flags<T> flags)
    	{
    		return flags._value;
    	}
    
    	/// <summary>
    	///     Implicit conversion from the underlying <typeparamref name="T" /> to first <see cref="Flags{T}" /> value.
    	/// </summary>
    	/// <param name="flags">The <typeparamref name="T" /> value.</param>
    	/// <returns>The value of <paramref name="flags" /> as first <see cref="Flags{T}" />.</returns>
    	[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms",
    		MessageId = "flags",
    		Justification = "This struct is first wrapper around Enum Flags, and relates to the term in question.")]
    	public static implicit operator Flags<T>(T flags)
    	{
    		return new Flags<T>(flags);
    	}
    
    	/// <summary>
    	///     Compares two <see cref="Flags{T}" /> instances to determine if they have equal values.
    	/// </summary>
    	/// <param name="first">The first <see cref="Flags{T}" />.</param>
    	/// <param name="second">The second <see cref="Flags{T}" />.</param>
    	/// <returns><c>true</c> if <paramref name="first" /> and <paramref name="second" /> are equal, <c>false</c> otherwise.</returns>
    	public static bool operator ==(Flags<T> first, Flags<T> second)
    	{
    		return first.Equals(second);
    	}
    
    	/// <summary>
    	///     Compares two <see cref="Flags{T}" /> instances to determine if they do not have equal values.
    	/// </summary>
    	/// <param name="first">The first <see cref="Flags{T}" />.</param>
    	/// <param name="second">The second <see cref="Flags{T}" />.</param>
    	/// <returns>
    	///     <c>true</c> if <paramref name="first" /> and <paramref name="second" /> are not equal, <c>false</c> if they
    	///     are.
    	/// </returns>
    	public static bool operator !=(Flags<T> first, Flags<T> second)
    	{
    		return !(first == second);
    	}
    	#endregion
    }
