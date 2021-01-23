	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Reflection;
	using System.Web;
	namespace YourNamespace.UI.Infrastructure
	{
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
		public class LowHighCheck : ValidationAttribute
		{
			private string[] PropertyList { get; set; }
			public LowHighCheck(params string[] propertyList)
			{
				this.PropertyList = propertyList;
			}
			public override object TypeId
			{
				get
				{
					return this;
				}
			}
			public override bool IsValid(object value)
			{
                // integers for an example - if complex objects you'll need to 
                // perform some more operations to compare them here
				int low = (int)PropertyList.GetValue(1);
				int high = (int)PropertyList.GetValue(2);
				if (high < low)
				{
					return false;
				}
				return true;
			}
		}
	}
	
