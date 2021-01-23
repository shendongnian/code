	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace Treeparse
	{
		class Program
		{
			static void Main(string[] args)
			{
				var input = "[Testing.User]| Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
				var t = StringTree.Parse(input);
				System.Diagnostics.Debugger.Break();
			}
		}
		public class StringTree
		{
			//Branching constants
			const string BranchOff = "(";
			const string BranchBack = ")";
			const string NextTwig = "|";
			//Content of this twig
			public string Text;
			//List of Sub-Twigs
			public List<StringTree> Twigs;
			[System.Diagnostics.DebuggerStepThrough()]
			public StringTree()
			{
				Text = "";
				Twigs = new List<StringTree>();
			}
			private static void ParseRecursive(StringTree Tree, string InputStr, ref int Position)
			{
				do {
					StringTree NewTwig = new StringTree();
					do {
						NewTwig.Text = NewTwig.Text + InputStr[Position];
						Position += 1;
					} while (!(Position == InputStr.Length || (new String[] { BranchBack, BranchOff, NextTwig }.ToList().Contains(InputStr[Position].ToString()))));
					Tree.Twigs.Add(NewTwig);
					if (Position < InputStr.Length && InputStr[Position].ToString() == BranchOff) { Position += 1; ParseRecursive(NewTwig, InputStr, ref Position); Position += 1; }
					if (Position < InputStr.Length && InputStr[Position].ToString() == BranchBack)
						break; // TODO: might not be correct. Was : Exit Do
					Position += 1;
				} while (!(Position >= InputStr.Length || InputStr[Position].ToString() == BranchBack));
			}
			/// <summary>
			/// Call this to parse the input into a StringTree objects using recursion
			/// </summary>
			public static StringTree Parse(string Input)
			{
				StringTree t = new StringTree();
				t.Text = "Root";
				int Start = 0;
				ParseRecursive(t, Input, ref Start);
				return t;
			}
		}
	}
