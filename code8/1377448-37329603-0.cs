	using System;
	using System.Collections.Specialized;
	using System.Globalization;
	using System.Web.Mvc;
	public class SingularOrPluralQueryStringValueProviderFactory : ValueProviderFactory
	{
		private readonly string singularKey;
		private readonly string pluralKey;
		public SingularOrPluralQueryStringValueProviderFactory(string singularKey, string pluralKey)
		{
			if (string.IsNullOrEmpty(singularKey))
				throw new ArgumentNullException("singularKey");
			if (string.IsNullOrEmpty(pluralKey))
				throw new ArgumentNullException("pluralKey");
			this.singularKey = singularKey;
			this.pluralKey = pluralKey;
		}
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new SingularOrPluralQueryStringValueProvider(this.singularKey, this.pluralKey, controllerContext.HttpContext.Request.QueryString);
		}
	}
	public class SingularOrPluralQueryStringValueProvider : IValueProvider
	{
		private readonly string singularKey;
		private readonly string pluralKey;
		private readonly NameValueCollection queryString;
		public SingularOrPluralQueryStringValueProvider(string singularKey, string pluralKey, NameValueCollection queryString)
		{
			if (string.IsNullOrEmpty(singularKey))
				throw new ArgumentNullException("singularKey");
			if (string.IsNullOrEmpty(pluralKey))
				throw new ArgumentNullException("pluralKey");
			this.singularKey = singularKey;
			this.pluralKey = pluralKey;
			this.queryString = queryString;
		}
		public bool ContainsPrefix(string prefix)
		{
			return this.GetSingularOrPluralValue(prefix) != null;
		}
		public ValueProviderResult GetValue(string key)
		{
			var value = this.GetSingularOrPluralValue(key);
			return (value != null) ? 
				new ValueProviderResult(value, value.ToString(), CultureInfo.InvariantCulture) : 
				null;
		}
		private bool IsKeyMatch(string key)
		{
			return (this.singularKey.Equals(key, StringComparison.OrdinalIgnoreCase) ||
				this.pluralKey.Equals(key, StringComparison.OrdinalIgnoreCase));
		}
		private string GetSingularOrPluralValue(string key)
		{
			if (this.IsKeyMatch(key))
			{
				return this.queryString[this.singularKey] ?? this.queryString[this.pluralKey];
			}
			return null;
		}
	}
