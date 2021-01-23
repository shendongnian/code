    using System;
    
    namespace MyReferencedAssembly
    {
    	/// <summary>
    	/// Use to force an assembly reference
    	/// </summary>
    	/// <seealso cref="System.Attribute" />
    	[AttributeUsage(AttributeTargets.Assembly)]
    	public class AssemblyReferenceAttribute : Attribute
    	{
    	}
    }
