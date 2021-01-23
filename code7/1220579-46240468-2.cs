    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Web.Script.Serialization;
    
    namespace SomeNamespace
    {
    	#region Class CustomJavaScriptSerializer
    
    	/// <summary>
    	/// Custom JavaScript serializer, see https://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptconverter%28v=vs.110%29.aspx
    	/// </summary>
    	/// <remarks>
    	/// Used to enhance functionality of standard <see cref="System.Web.Script.Serialization.JavaScriptSerializer"/>. 
    	/// E.g. to support <see cref="JsonPropertyAttribute"/> that provides some properties known from Newtonsoft's JavaScript serializer, 
    	/// see https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm.
    	/// Additionally, there is an attribute <see cref="JsonClassAttribute"/> that can be applied to the class 
    	/// to manipulate JSON serialization behavior of all properties of the class.
    	/// Use this JSON serializer when including Newtonsoft's JavaScript serializer is not an option for you.
    	/// 
    	/// Usage: 
    	/// 
    	///  - Just derive your class to be JSON serialized / deserialized from this class. 
    	///  - You now can decorate the properties of your class with e.g. [JsonProperty( "someName" )]. See <see cref="JsonPropertyAttribute"/> for details.
    	///  - Additionally, you can decorate your class with e.g. [JsonClass( DoNotLowerCaseFirstLetter = true)]. See <see cref="JsonClassAttribute"/> for details.
    	///  - Important! Use static methods <see cref="JsonSerialize"/> and <see cref="JsonDeserialize"/> of this class for JSON serialization / deserialization.
    	///  - For further customization specific to your class, you can override <see cref="GetSerializedProperty"/> and <see cref="SetDeserializedProperty"/> in your derived class.
    	///   
    	/// Example:
    	/// 
    	/// <![CDATA[
    	/// 
    	/// [JsonClass( DoNotLowerCaseFirstLetter = true )]
    	/// public class SomeClass: CustomJavaScriptSerializer
    	/// {
    	/// 	
    	/// 	/// <summary>
    	/// 	/// The tooltip. Will be transferred to JavaScript as "tooltext".
    	/// 	/// </summary>
    	/// 	[JsonProperty( "tooltext" )]
    	/// 	public string Tooltip
    	/// 	{
    	/// 		get;
    	/// 		set;
    	/// 	}
    	/// 	
    	///		...
    	///	}
    	///	
    	/// ]]>
    	/// </remarks>
    	public abstract class CustomJavaScriptSerializer : JavaScriptConverter
    	{
    		#region Fields
    
    		/// <summary>
    		/// Dictionary to collect all derived <see cref="CustomJavaScriptSerializer"/> to be registered with <see cref="JavaScriptConverter.RegisterConverters"/>
    		/// </summary>
    		private static Dictionary<Type, CustomJavaScriptSerializer> convertersToRegister = new Dictionary<Type, CustomJavaScriptSerializer>();
    
    		/// <summary>
    		/// Sync for <see cref="convertersToRegister"/>.
    		/// </summary>
    		private static readonly object sync = new object();
    
    		#endregion
    
    		#region Properties
    
    		/// <summary>
    		/// All derived <see cref="CustomJavaScriptSerializer"/> to be registered with <see cref="JavaScriptConverter.RegisterConverters"/>
    		/// </summary>
    		public static IEnumerable<CustomJavaScriptSerializer> ConvertersToRegister
    		{
    			get
    			{
    				return CustomJavaScriptSerializer.convertersToRegister.Values;
    			}
    		}
    
    		/// <summary>
    		/// <see cref="JsonClassAttribute"/> retrieved from decoration of the derived class.
    		/// </summary>
    		/// <remarks>
    		/// Is only set when an instance of this class is used for serialization. See constructor for details.
    		/// </remarks>
    		protected JsonClassAttribute ClassAttribute
    		{
    			get;
    			private set;
    		}
    
    		#endregion
    
    		#region Constructors
    
    		/// <summary>
    		/// Default constructor
    		/// </summary>
    		public CustomJavaScriptSerializer()
    		{
    			Type type = this.GetType();
    
    			if ( CustomJavaScriptSerializer.convertersToRegister.ContainsKey( type ) )
    				return;
    
    			lock( sync )
    			{
    				// Remember this CustomJavaScriptSerializer instance to do serialization for this type.
    				if ( CustomJavaScriptSerializer.convertersToRegister.ContainsKey( type ) )
    					return;
    
    				// Performance: Set ClassAttribute only for the instance used for serialization.
    				this.ClassAttribute = ( this.GetType().GetCustomAttributes( typeof( JsonClassAttribute ), true ).FirstOrDefault() as JsonClassAttribute ) ?? new JsonClassAttribute();
    				convertersToRegister[ type ] = this;
    			}
    		}
    
    		#endregion
    
    		#region Public Methods
    
    		/// <summary>
    		/// Converts <paramref name="obj"/> to a JSON string.
    		/// </summary>
    		/// <param name="obj">The object to serialize.</param>
    		/// <returns>The serialized JSON string.</returns>
    		public static string JsonSerialize( object obj )
    		{
    			var serializer = new JavaScriptSerializer();
    			serializer.RegisterConverters( CustomJavaScriptSerializer.ConvertersToRegister );
    			serializer.MaxJsonLength = int.MaxValue;
    			return serializer.Serialize( obj );
    		}
    
    		/// <summary>
    		/// Converts a JSON-formatted string to an object of the specified type.
    		/// </summary>
    		/// <param name="input">The JSON string to deserialize.</param>
    		/// <param name="targetType">The type of the resulting object.</param>
    		/// <returns>The deserialized object.</returns>
    		public static object JsonDeserialize( string input, Type targetType )
    		{
    			var serializer = new JavaScriptSerializer();
    			serializer.RegisterConverters( CustomJavaScriptSerializer.ConvertersToRegister );
    			serializer.MaxJsonLength = int.MaxValue;
    			return serializer.Deserialize( input, targetType );
    		}
    
    		/// <summary>
    		/// Converts the specified JSON string to an object of type <typeparamref name="T"/>.
    		/// </summary>
    		/// <typeparam name="T">The type of the resulting object.</typeparam>
    		/// <param name="input">The JSON string to be deserialized.</param>
    		/// <returns>The deserialized object.</returns>
    		public static T JsonDeserialize<T>( string input )
    		{
    			return (T)CustomJavaScriptSerializer.JsonDeserialize( input, typeof( T ) );
    		}
    
    		/// <summary>
    		/// Get this object serialized as JSON string.
    		/// </summary>
    		/// <returns>This object as JSON string.</returns>
    		public string ToJson()
    		{
    			return CustomJavaScriptSerializer.JsonSerialize( this );
    		}
    
    		#endregion
    
    		#region Overrides
    
    		/// <summary>
    		/// Return list of supported types. This is just a derived class here.
    		/// </summary>
    		[ScriptIgnore]
    		public override IEnumerable<Type> SupportedTypes
    		{
    			get
    			{
    				return new ReadOnlyCollection<Type>( new List<Type>(){ this.GetType() } );
    			}
    		}
    
    		/// <summary>
    		/// Serialize the passed <paramref name="obj"/>.
    		/// </summary>
    		/// <param name="obj">The object to serialize.</param>
    		/// <param name="serializer">The <see cref="JavaScriptSerializer"/> calling this method.</param>
    		/// <returns>A dictionary with name value pairs representing property name value pairs as they shall appear in JSON. </returns>
    		public override IDictionary<string, object> Serialize( object obj, JavaScriptSerializer serializer )
    		{
    			var result = new Dictionary<string, object>();
    
    			if ( obj == null )
    				return result;
    
    			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
    
    			PropertyInfo[] properties = this.GetType().GetProperties( bindingFlags );
    
    			foreach ( PropertyInfo property in properties )
    			{
    				KeyValuePair<string, object> kvp = this.GetSerializedProperty( obj, property );
    				if ( !string.IsNullOrEmpty( kvp.Key ) )
    					result[ kvp.Key ] = kvp.Value;
    			}
    
    			return result;
    		}
    
    		/// <summary>
    		/// Deserialize <paramref name="dictionary"/> to <paramref name="type"/>.
    		/// </summary>
    		/// <remarks>
    		/// Reverse method to <see cref="Serialize"/>
    		/// </remarks>
    		/// <param name="dictionary">The dictionary to be deserialized.</param>
    		/// <param name="type">Type to deserialize to. This is the type of the derived class, see <see cref="SupportedTypes"/>.</param>
    		/// <param name="serializer">The <see cref="JavaScriptSerializer"/> calling this method.</param>
    		/// <returns>An object of type <paramref name="type"/> with property values set from <paramref name="dictionary"/>.</returns>
    		public override object Deserialize( IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer )
    		{
    			if ( dictionary == null )
    				throw new ArgumentNullException( "dictionary" );
    
    			if ( type == null )
    				throw new ArgumentNullException( "type" );
    
    			if ( serializer == null )
    				throw new ArgumentNullException( "serializer" );
    
    			// This will fail if type has no default constructor.
    			object result = Activator.CreateInstance( type );
    
    			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
    
    			PropertyInfo[] properties = this.GetType().GetProperties( bindingFlags );
    
    			foreach ( PropertyInfo property in properties )
    			{
    				this.SetDerializedProperty( result, property, dictionary, serializer );
    			}
    
    			return result;
    		}
    
    		#endregion
    
    		#region Protected Methods
    
    		/// <summary>
    		/// Get a key value pair as base for serialization, based on the passed <paramref name="property"/>.
    		/// </summary>
    		/// <remarks>
    		/// The returned <see cref="KeyValuePair"/> key represents the property's name in JSON, the value its value.
    		/// </remarks>
    		/// <param name="obj">The object to serialize.</param>
    		/// <param name="property">The <see cref="PropertyInfo"/>To be serialized.</param>
    		/// <returns>The requested key value pair or an empty key value pair (key = null) to ignore this property.</returns>
    		protected virtual KeyValuePair<string, object> GetSerializedProperty( object obj, PropertyInfo property )
    		{
    			var result = new KeyValuePair<string, object>();
    
    			if ( property == null || !property.CanRead )
    				return result;
    
    			object value = property.GetValue( obj );
    			if ( value == null && !this.ClassAttribute.SerializeNullValues )
    				return result;
    
    			JsonPropertyAttribute jsonPropertyAttribute = this.GetJsonPropertyAttribute( property );
    			if ( jsonPropertyAttribute == null || jsonPropertyAttribute.Ignored )
    				return result;
    
    			if ( value != null && jsonPropertyAttribute.UseToString )
    				value = value.ToString();
    
    			string name = jsonPropertyAttribute.PropertyName;
    			return new KeyValuePair<string, object>( name, value );
    		}
    
    		/// <summary>
    		/// Set <paramref name="property"/> of <paramref name="obj"/> with value provided in <paramref name="dictionary"/>.
    		/// </summary>
    		/// <param name="obj">The object to set <paramref name="property of"/>.</param>
    		/// <param name="property">The property to set its value.</param>
    		/// <param name="dictionary">Dictionary with property name - value pairs to query for <paramref name="property"/> value.</param>
    		/// <param name="serializer">The <see cref="JavaScriptSerializer"/> calling this method.</param>
    		public virtual void SetDerializedProperty( object obj, PropertyInfo property, IDictionary<string, object> dictionary, JavaScriptSerializer serializer )
    		{
    			if ( obj == null || property == null || !property.CanWrite || dictionary == null || serializer == null )
    				return;
    
    			JsonPropertyAttribute jsonPropertyAttribute = this.GetJsonPropertyAttribute( property );
    			if ( jsonPropertyAttribute == null || jsonPropertyAttribute.Ignored || jsonPropertyAttribute.UseToString )
    				return;
    
    			string name = jsonPropertyAttribute.PropertyName;
    			if ( !dictionary.ContainsKey( name ) )
    				return;
    
    			object value = dictionary[ name ];
    
    			// Important! Use JavaScriptSerializer.ConvertToType so that CustomJavaScriptSerializers of properties of this class are called recursively. 
    			object convertedValue = serializer.ConvertToType( value, property.PropertyType );
    			property.SetValue( obj, convertedValue );
    		}
    
    		/// <summary>
    		/// Gets a <see cref="JsonPropertyAttribute"/> for the passed <see cref="PropertyInfo"/>.
    		/// </summary>
    		/// <param name="property">The property to examine. May not be null.</param>
    		/// <returns>A <see cref="JsonPropertyAttribute"/> with properties set to be used directly as is, never null.</returns>
    		protected JsonPropertyAttribute GetJsonPropertyAttribute( PropertyInfo property )
    		{
    			if ( property == null )
    				throw new ArgumentNullException( "property" );
    
    			object[] attributes = property.GetCustomAttributes( true );
    
    			JsonPropertyAttribute jsonPropertyAttribute = null;
    			bool ignore = false;
    
    			foreach ( object attribute in attributes )
    			{
    				if ( attribute is ScriptIgnoreAttribute )
    					ignore = true;
    
    				if ( attribute is JsonPropertyAttribute )
    					jsonPropertyAttribute = (JsonPropertyAttribute)attribute;
    			}
    
    			JsonPropertyAttribute result = jsonPropertyAttribute ?? new JsonPropertyAttribute();
    			result.Ignored |= ignore;
    
    			if ( string.IsNullOrWhiteSpace( result.PropertyName ) )
    				result.PropertyName = property.Name;
    
    			if ( !this.ClassAttribute.DoNotLowerCaseFirstLetter && ( jsonPropertyAttribute == null || string.IsNullOrWhiteSpace( jsonPropertyAttribute.PropertyName ) ) )
    			{
    				string name = result.PropertyName.Substring( 0, 1 ).ToLowerInvariant();
    				if ( result.PropertyName.Length > 1 )
    					name += result.PropertyName.Substring( 1 );
    				result.PropertyName = name;
    			}
    
    			return result;
    		}
    
    		#endregion
    	}
    
    	#endregion
    
    	#region Class JsonClassAttribute
    
    	/// <summary>
    	/// Attribute to be used in conjunction with <see cref="CustomJavaScriptSerializer"/>.
    	/// </summary>
    	/// <remarks>
    	/// Decorate your class derived from <see cref="CustomJavaScriptSerializer"/> with this attribute to 
    	/// manipulate how JSON serialization / deserialization is done for all properties of your derived class.
    	/// </remarks>
    	[AttributeUsage( AttributeTargets.Class )]
    	public class JsonClassAttribute : Attribute
    	{
    		#region Properties
    
    		/// <summary>
    		/// By default, all property names are automatically converted to have their first letter lower case (as it is convention in JavaScript). Set this to true to avoid that behavior.
    		/// </summary>
    		public bool DoNotLowerCaseFirstLetter
    		{
    			get;
    			set;
    		}
    
    		/// <summary>
    		/// By default, properties with value null are not serialized. Set this to true to avoid that behavior.
    		/// </summary>
    		public bool SerializeNullValues
    		{
    			get;
    			set;
    		}
    
    		#endregion
    	}
    
    	#endregion
    
    	#region Class JsonPropertyAttribute
    
    	/// <summary>
    	/// Attribute to be used in conjunction with <see cref="CustomJavaScriptSerializer"/>.
    	/// </summary>
    	/// <remarks>
    	/// Among others, used to define a property's name when being serialized to JSON. 
    	/// Implements some functionality found in Newtonsoft's JavaScript serializer, 
    	/// see https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm
    	/// </remarks>
    	[AttributeUsage( AttributeTargets.Property )]
    	public class JsonPropertyAttribute : Attribute
    	{
    		#region Properties
    
    		/// <summary>
    		/// True to ignore this property.
    		/// </summary>
    		public bool Ignored
    		{
    			get;
    			set;
    		}
    
    		/// <summary>
    		/// Gets or sets the name of the property. 
    		/// </summary>
    		public string PropertyName
    		{
    			get;
    			set;
    		}
    
    		/// <summary>
    		/// When true, the value of this property is serialized using value.ToString().
    		/// </summary>
    		/// <remarks>
    		/// Can be handy when serializing e.g. enums or types.
    		/// Do not set this to true when deserialization is needed, since there is no general inverse method to ToString().
    		/// When this is true, the property is just ignored when deserializing.
    		/// </remarks>
    		public bool UseToString
    		{
    			get;
    			set;
    		}
    
    		#endregion
    
    		#region Constructors
    
    		/// <summary>
    		/// Default constructor
    		/// </summary>
    		public JsonPropertyAttribute()
    		{
    		}
    
    		/// <summary>
    		/// Initializes a new instance of the <see cref="JsonPropertyAttribute"/>  class with the specified name. 
    		/// </summary>
    		/// <param name="propertyName">Name of the property</param>
    		public JsonPropertyAttribute( string propertyName )
    		{
    			this.PropertyName = propertyName;
    		}
    
    		#endregion
    	}
    
    	#endregion
    }
