	#region CustomJavaScriptSerializer
	/// <summary>Tests behavior of CustomJavaScriptSerializer.</summary>
	[TestMethod]
	public void TestCustomJavaScriptSerializer()
	{
		// 11
		var dataItem11 = new JsonSerializeTest1();
		dataItem11.Label = "LabelName";
		dataItem11.Value = 5;
		dataItem11.Test = TestEnum.B;
		dataItem11.Tooltip = "TooltipName";
		string json11 = dataItem11.ToJson();
		Assert.IsTrue( json11 == "{\"label\":\"LabelName\",\"value\":5,\"test\":2,\"tooltext\":\"TooltipName\"}" );
		JsonSerializeTest1 deserialized11 = CustomJavaScriptSerializer.JsonDeserialize<JsonSerializeTest1>( json11 );
		Assert.IsNotNull( deserialized11 );
		Assert.IsTrue( deserialized11.Equals( dataItem11 ) );
		// 12
		var dataItem12 = new JsonSerializeTest1();
		dataItem12.Value = 5;
		dataItem12.Test = TestEnum.A;
		dataItem12.Tooltip = "TooltipName";
		string json12 = dataItem12.ToJson();
		Assert.IsTrue( json12 == "{\"value\":5,\"test\":1,\"tooltext\":\"TooltipName\"}" );
		JsonSerializeTest1 deserialized12 = CustomJavaScriptSerializer.JsonDeserialize<JsonSerializeTest1>( json12 );
		Assert.IsNotNull( deserialized12 );
		Assert.IsTrue( deserialized12.Equals( dataItem12 ) );
		// 21
		var dataItem21 = new JsonSerializeTest2();
		dataItem21.Label = "LabelName";
		dataItem21.Value = 5;
		dataItem21.Test = TestEnum.B;
		dataItem21.Tooltip = "TooltipName";
		string json21 = dataItem21.ToJson();
		Assert.IsTrue( json21 == "{\"Test\":\"B\",\"Label\":\"LabelName\",\"Value\":5}" );
		JsonSerializeTest2 deserialized21 = CustomJavaScriptSerializer.JsonDeserialize<JsonSerializeTest2>( json21 );
		Assert.IsNotNull( deserialized21 );
		Assert.IsTrue( deserialized21.Label == "LabelName" );
		Assert.IsTrue( deserialized21.Value == 5 );
		// No mistake! UseToString = true here. See JsonPropertyAttribute.UseToString. 
		Assert.IsTrue( deserialized21.Test == 0 );
		Assert.IsTrue( deserialized21.Tooltip == null );
		// 22
		var dataItem22 = new JsonSerializeTest2();
		dataItem22.Tooltip = "TooltipName";
		string json22 = dataItem22.ToJson();
		Assert.IsTrue( json22 == "{\"Test\":\"0\",\"Label\":null,\"Value\":null}" );
		JsonSerializeTest2 deserialized22 = CustomJavaScriptSerializer.JsonDeserialize<JsonSerializeTest2>( json22 );
		Assert.IsNotNull( deserialized22 );
		Assert.IsTrue( deserialized22.Label == null );
		Assert.IsTrue( deserialized22.Value == null );
		Assert.IsTrue( deserialized22.Test == 0 );
		Assert.IsTrue( deserialized22.Tooltip == null );
		var list = new List<JsonSerializeTest1>() { dataItem11, dataItem12 };
		var json = CustomJavaScriptSerializer.JsonSerialize( list );
		List<JsonSerializeTest1> deserialized = CustomJavaScriptSerializer.JsonDeserialize<List<JsonSerializeTest1>>( json );
		Assert.IsNotNull( deserialized );
		Assert.IsTrue( deserialized.Count == 2 );
		Assert.IsTrue( deserialized[ 0 ].Equals( deserialized11 ) );
		Assert.IsTrue( deserialized[ 1 ].Equals( deserialized12 ) );
	}
	[JsonClass( DoNotLowerCaseFirstLetter = true, SerializeNullValues = true )]
	public class JsonSerializeTest2 : JsonSerializeTest1
	{
		/// <summary>
		/// A tooltip
		/// </summary>
		[JsonProperty( Ignored = true )]
		public override string Tooltip
		{
			get;
			set;
		}
		/// <summary>
		/// An enum
		/// </summary>
		[JsonProperty( UseToString = true )]
		public override TestEnum Test
		{
			get;
			set;
		}
	}
	public class JsonSerializeTest1 : CustomJavaScriptSerializer
	{
		/// <summary>
		/// A label
		/// </summary>
		public virtual string Label
		{
			get;
			set;
		}
		/// <summary>
		/// A Value
		/// </summary>
		public virtual decimal? Value
		{
			get;
			set;
		}
		/// <summary>
		/// An enum
		/// </summary>
		public virtual TestEnum Test
		{
			get;
			set;
		}
		/// <summary>
		/// A tooltip
		/// </summary>
		[JsonProperty( "tooltext" )]
		public virtual string Tooltip
		{
			get;
			set;
		}
		/// <summary>
		/// Whether this object is the same as <paramref name="obj"/>.
		/// </summary>
		/// <returns>True = <paramref name="obj"/> is the same as this object, false otherwise.</returns>
		public override bool Equals( object obj )
		{
			var other = obj as JsonSerializeTest1;
			// Cast to object to avoid that it calls overridden == operator here.
			if ( (object)other == null )
				return false;
			return this.Label == other.Label && this.Value == other.Value && this.Test == other.Test && this.Tooltip == other.Tooltip;
		}
		/// <summary>
		/// Get hash code for comparison
		/// </summary>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public enum TestEnum
	{
		A = 1,
		B = 2
	}
	#endregion
