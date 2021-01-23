	namespace Car_Management
	{
		class Car
		{
			public Car()
			{
				Year = 0;
				Mileage = 0;
				Colour = "";
				Model = "";
			}
			//name properties
			public string Model {get;set;}
			public string Colour {get;set;}
			public double Mileage {get;set;}
			public int Year {get;set;}
			//returns string consisting of model, year, mileage, colour
			public string GetInfo(string sep)
			{
				sep = ": ";
				return model + sep + colour + sep + mileage.ToString("c") + sep + year.ToString();
			}
		}
	}
