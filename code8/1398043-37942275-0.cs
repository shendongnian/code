	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Web;
	using System.Xml.Linq;
	namespace StackOverflow
	{
		class Program
		{
			const string A = "A";
			const string B = "B";
			const string C = "C";
			const string D = "D";
			const string E = "E";
			const string F = "F";
			const string S = "sunny";
			const string R = "raining";
			public abstract class Route
			{
				public abstract void Intro();
				public abstract void Distance();
				public abstract void SurfaceType();
			}
			public class CandyLane : Route
			{
				public double DistanceInMiles = 84;
				public override void Intro()
				{
					Console.WriteLine("[D] Candy Lane --------");
				}
				public override void Distance()
				{
					Console.WriteLine("84 Miles to end of route");
				}
				public override void SurfaceType()
				{
					Console.WriteLine("Smooth Surface Type");
				}
			}
			public class BostonAvenue : Route
			{
				public double DistanceInMiles = 126;
				public override void Intro()
				{
					Console.WriteLine("[E] Boston Avenue --------");
				}
				public override void Distance()
				{
					Console.WriteLine("126 Miles to end of route");
				}
				public override void SurfaceType()
				{
					Console.WriteLine("Rough Surface Type");
				}
			}
			public class DenhamVale : Route
			{
				public  double DistanceInMiles = 39;
				public override void Intro()
				{
					Console.WriteLine("[F] Denham Vale --------");
				}
				public override void Distance()
				{
					Console.WriteLine("39 Miles to end of route");
				}
				public override void SurfaceType()
				{
					Console.WriteLine("Medium Surface Type");
				}
			}
			public abstract class Cars
			{
				public abstract void Speed();
				public abstract void Engine();
				public abstract void Intro();
			}
			public class Toyota : Cars
			{
				public double SpeedMph = 47;
				public override void Intro()
				{
					Console.WriteLine("[A] TOYOTA---------");
				}
				public override void Speed()
				{
					Console.WriteLine("Toyota Speed = 47MPH");
				}
				public override void Engine()
				{
					Console.WriteLine("Engine Type = 1.2 litre engine");
				}
			}
			public class Fiat : Cars
			{
				public double SpeedMph = 76;
				public override void Intro()
				{
					Console.WriteLine("[B] FIAT---------");
				}
				public override void Speed()
				{
					Console.WriteLine("Fiat  Speed = 76MPH");
				}
				public override void Engine()
				{
					Console.WriteLine("Engine = 1.3 litre engine");
				}
			}
			public class Honda : Cars
			{
				public double SpeedMph = 94;
				public override void Intro()
				{
					Console.WriteLine("[C] HONDA---------");
				}
				public override void Speed()
				{
					Console.WriteLine("Honda Speed = 94MPH");
				}
				public override void Engine()
				{
					Console.WriteLine("Engine = 1.3 litre engine");
				}
				public static void Main()
				{
					// TESTING THE METHOD
					var toyota = new  Toyota();
					var demhamVal = new DenhamVale();
					CalulateSdt(demhamVal.DistanceInMiles, toyota.SpeedMph);
					Console.WriteLine("Welcome To My Program");
					Console.WriteLine("Please See List and pick a car for your journey: ");
					Toyota t = new Toyota();
					t.Intro();
					t.Speed();
					t.Engine();
					Fiat f = new Fiat();
					f.Intro();
					f.Speed();
					f.Engine();
					Honda h = new Honda();
					h.Intro();
					h.Speed();
					h.Engine();
					string input;
					input = Console.ReadLine();
					
					if (string.Equals(A, input, StringComparison.CurrentCultureIgnoreCase))
					{
						string input2;
						Console.WriteLine("You have chosen to drive the toyota." + Environment.NewLine + "Please pick a route: ");
						List<Route> Routes = new List<Route>();
						Routes.Add(new CandyLane());
						Routes.Add(new BostonAvenue());
						Routes.Add(new DenhamVale());
						foreach (Route Route in Routes)
						{
							Route.Intro();
							Route.Distance();
							Route.SurfaceType();
						}
						input2 = Console.ReadLine();
						if (string.Equals(D, input2, StringComparison.CurrentCultureIgnoreCase))
						{
							string input3;
							Console.WriteLine("You have chosen: Candy Lane" + Environment.NewLine + "Is it raining or sunny?");
							input3 = Console.ReadLine();
							if (string.Equals(R, input3, StringComparison.CurrentCultureIgnoreCase))
							{
								Console.WriteLine("You have chosen Raining. + 10 minutes...");
							}
						}
						else if (string.Equals(E, input2, StringComparison.CurrentCultureIgnoreCase))
						{
							Console.WriteLine("You have chosen: Boston Avenue" + Environment.NewLine + "Is it raining or sunny?");
						}
						else if (string.Equals(F, input2, StringComparison.CurrentCultureIgnoreCase))
						{
							Console.WriteLine("You have chosen: Denham Vale" + Environment.NewLine + "Is it raining or sunny?");
						}
						else
						{
							Console.WriteLine("This Route Doesnt Exsist");
						}
					}
					else if (string.Equals(B, input, StringComparison.CurrentCultureIgnoreCase))
					{
						string input2;
						Console.WriteLine("You have chosen to drive the Fiat." + Environment.NewLine + "Please pick a route: ");
						List<Route> Routes = new List<Route>();
						Routes.Add(new CandyLane());
						Routes.Add(new BostonAvenue());
						Routes.Add(new DenhamVale());
						foreach (Route Route in Routes)
						{
							Route.Intro();
							Route.Distance();
							Route.SurfaceType();
						}
						input2 = Console.ReadLine();
						if (string.Equals(D, input2, StringComparison.CurrentCultureIgnoreCase))
						{
							Console.WriteLine("You have chosen: Candy Lane" + Environment.NewLine + "Is it raining or sunny?");
						}
					}
					else if (string.Equals(C, input, StringComparison.CurrentCultureIgnoreCase))
					{
						string input2;
						Console.WriteLine("You have chosen to drive the Honda." + Environment.NewLine + "Please pick a route: ");
						List<Route> Routes = new List<Route>();
						Routes.Add(new CandyLane());
						Routes.Add(new BostonAvenue());
						Routes.Add(new DenhamVale());
						foreach (Route Route in Routes)
						{
							Route.Intro();
							Route.Distance();
							Route.SurfaceType();
						}
						input2 = Console.ReadLine();
						if (string.Equals(D, input2, StringComparison.CurrentCultureIgnoreCase))
						{
							Console.WriteLine("You have chosen: Candy Lane" + Environment.NewLine + "Is it raining or sunny?");
						}
					}
				}
			}
			/*
				To find a time, we need to divide distance by speed. 
				Chris cycles at an average speed of 8 mph. If he cycles for 6½ hours, 
				how far does he travel? To find a distance, we need to multiply speed by time. (http://www.cimt.org.uk/siteinfo/plymouth404.htm)
			*/
			public static void CalulateSdt(double distanceInMiles, double speedMph)
			{
				var sdt = distanceInMiles/speedMph;
				sdt = sdt*60;
				Console.WriteLine($"Speed Distance Time : {sdt} minutes");
				Console.WriteLine();
			}
		}
	}
