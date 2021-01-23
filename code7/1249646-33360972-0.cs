		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		namespace Triangle
		{
			class Program
			{
				static string Line(int i, int n, string star, string space)
				{
					string rslt = String.Empty.PadRight(n - 1 - i, ' ') + star;
					if (i == 0) return rslt;
					for (int j = 0; j < (i > 0 ? 2 * i - 1 : 0) / 2; j++ rslt += space + (i >= (n - 1) ? star : space)) ;
					rslt += space + star;
					return rslt;
				}
				static void Main(string[] args)
				{
					int n = 40;
					for (int i = 0; i < n; i++)
					{
						Console.WriteLine(Line(i,n, "*", " "));
					}
					Console.ReadLine();
				}
			}
		}
