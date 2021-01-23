	<#@ template debug="false" hostspecific="false" language="C#" #>
	<#@ assembly name="System.Core" #>
	<#@ output extension=".cs" #>
	using System.Collections.Generic;
	<#
	string[] indexTypeNames = { "Index1", "Index2" };
	foreach (var name in indexTypeNames)
	{
		string collectionName = name + "List";
	#>
	public struct <#= name #>
	{
		public int Value { get; set; }
	}
	public class <#= collectionName #><T>
	{
		private List<T> _inner = new List<T>();
		public T this[<#= name #> index]
		{
			get { return _inner[index.Value]; }
			set { _inner[index.Value] = value; }
		}
		// Other desired IList<T> methods.
	}
	<#
	}
	#>
