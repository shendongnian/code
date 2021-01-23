	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace TestForm
	{
		class UserClass
		{
			private int m_underProp;
			public UserClass(string prop2Disp, int anotherObj, bool isChecked = false)
			{
				PropToDisplay = prop2Disp;
				IsChecked = isChecked;
				AnotherProp = anotherObj;
			}
			public UserClass()
			{
				PropToDisplay = string.Empty;
				IsChecked = false;
				AnotherProp = 0;
			}
			public string PropToDisplay
			{
				get;
				set;
			}
			public bool IsChecked
			{
				get;
				set;
			}
			//	Anything you want
			public int AnotherProp
			{
				get
				{
					return m_underProp;
				}
				set
				{
					m_underProp = value;
				}
			}
			//	For monitoring
			public string ShowVarState()
			{
				StringBuilder str = new StringBuilder();
				str.AppendFormat("- PropToDisplay: {0}", PropToDisplay);
				str.AppendLine();
				str.AppendFormat("- IsChecked: {0}", IsChecked);
				str.AppendLine();
				str.AppendFormat("- AnotherProp: {0}", AnotherProp.ToString());
				return str.ToString();
			}
		}
	}
