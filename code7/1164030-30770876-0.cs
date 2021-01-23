            public class Base
            {
                //This is JSON object's attribute.
                public string CPU {get; set;}
                public string PSU { get; set; }
                public List<string> Drives { get; set; }
                public string price { get; set; }
                //and others...
            }
    
            public class newBase : Base
            {
                ////same
                //public string CPU { get; set; }
                //public string PSU { get; set; }
                //public List<string> Drives { get; set; }
    
                //convert to new type
                public decimal price { get; set; }  //to other type you want
                //Added new item
                public string from { get; set; }
            }
        public class ConvertBase : CustomCreationConverter<Base>
        {
            public override Base Create(Type objectType)
            {
                return new newBase();
            }
        }
        static void Main(string[] args)
        {
            //from http://www.newtonsoft.com/json/help/html/ReadJsonWithJsonTextReader.htm (creadit) + modify by me
            string SimulateJsonInput = @"{'CPU': 'Intel', 'PSU': '500W', 'Drives': ['DVD read/writer', '500 gigabyte hard drive','200 gigabype hard drive'], 'price' : '3000', 'from': 'Asus'}";
            JsonSerializer serializer = new JsonSerializer();
            Base Object = JsonConvert.DeserializeObject<Base>(SimulateJsonInput);
            Base converted = JsonConvert.DeserializeObject<Base>(SimulateJsonInput, new ConvertBase());
            newBase newObject = (newBase)converted;
            //Console.Write(Object.from);
            Console.WriteLine("Newly converted atrribute type attribute =" + " " + newObject.price.GetType());
            Console.WriteLine("Newly added attribute =" + " " + newObject.from);
            Console.Read();   
        }
