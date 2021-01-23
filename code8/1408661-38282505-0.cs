    public class City
    {
        public string name { get; set; }
        public int cityCode { get; set; }
        public District distict { get; set; }
        public List<District> districts { get; set; }
        public static City Convert(string strCity)
        {
            var strArr = strCity.Split('|');
            var cityObj = new City();
            cityObj.name = strArr[0];
            cityObj.cityCode =int.Parse(strArr[1]);
            cityObj.distict = new District() {district= strArr[2], zipCode = strArr[3] };
            return cityObj;
        }
    }
    public class District
    {
        public string district { get; set; }
        public string zipCode { get; set; }
        public override string ToString()
        {
           return this.district + ":" + this.zipCode;
        }
    }
    public class LinqTest
    {
        public void ReadCsv()
        {
            var data = File.ReadLines(".\\test.csv").Skip(1)
                .Select(x => City.Convert(x)).GroupBy(x => new { Name = x.name, Code = x.cityCode })
                .Select(x => new City() { name = x.Key.Name, cityCode = x.Key.Code, districts = x.Select(item => item.distict).ToList() });
            foreach (var item in data)
            {
                System.Diagnostics.Debug.WriteLine($"Name:{item.name} Code: {item.cityCode} Districts: {string.Join(",", item.districts)}");
            }
        }
    }
