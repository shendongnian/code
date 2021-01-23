    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	public class Test
	{
		public static void Main()
		{
			//other streamreader code
				string[] splitsByLine = new string[] { "AnimModByxXx2o1o.cs, 18616", 
													   "anims.cs, 18780", 
													   "Dance.cs, 18661", 
													   "emergencylights.cs, 32213", 
													   "fps-de-limiter.cs, 17575", 
													   "neon.cs, 19019", 
													   "StreamMemFix.cs, 17560", 
													   "sun.cs, 17662", 
													   "WEATHERMENUE.cs, 18437", 
													   "anim.cs, 17637", 
													   "anim[0].cs, 20684", 
													   "anim_0_.cs, 19392", 
													   "anim1.cs, 18744", 
													   "anim2.cs, 19012", 
													   "Anim4.cs, 22900", 
													   "anim228.cs, 19465", 
														"" };
				if (splitsByLine != null && splitsByLine.Any()) // Test
				{
					foreach (string s in splitsByLine)
					{
						var nameAndSize = s.Split(',');
						if (nameAndSize != null && nameAndSize.Any() && nameAndSize.Count() > 1) // Test
						{
							Console.WriteLine(String.Concat(nameAndSize[0], " - ", Convert.ToInt64(nameAndSize[1])));
							//FileNameAndSizes.Add(nameAndSize[0], Convert.ToInt64(nameAndSize[1]));
						}
					}
				}
		}
	}
