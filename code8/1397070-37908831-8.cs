    public class CountriesFactory
    {
    	private static List<Country> _countries = new List<Country>()
    	{
    		new Country("Spain", "Spa"),
    		new Country("Germany", "Ger")
    	}
    
    	public static Country GetCountryByName(string countryName)
    	{
    		return _countries.Where(p => p.CountryName == countryName).FirstOrDefault() ?? Country.NONE;
    	}
    }
    
    public class Country
    {
    	public string CountryName { get; private set; }
    	public string ThreeLetterCode { get; private set; }
    
    	public const Country NONE = new Country("", "");
    
    	public Country (string countryName, string threeLetterCode)
    	{
    		this.CountryName = countryName;
    		this.ThreeLetterCode = threeLetterCode;
    	}
    }
    
    public class Person
    {
    	public string Name { get; set; }
    	public string Surname { get; set; }
    	public Country Country { get; set; }
    
    	public override string ToString()
    	{
    		return string.Format("{0} {1}. ({2})", Name, Surname[0].ToString(), Country.ThreeLetterCode);
    	}
    }
