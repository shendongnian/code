    using System;
    using Newtonsoft.Json.Converters;
    
    namespace Test
    {
        class JsonParser
        {
            public static void Main(string[] args)
            {
                string jsonStr = @"{'orders':[
                                {'id':41,
                                'billing_address':{'first_name':'HARSH','last_name':'KANTHARIA','company':'ITACHI GROUP','address_1':'20 dhanlaxmi bunglows','address_2':'nr nakshatra appartment,pal','city':'surat','state':'GJ','postcode':'395009','country':'IN','email':'harsh@resolutesolutions.in','phone':'9723638788'},
                                }]}";
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonStr);
                Console.WriteLine(data.orders[0].billing_address.first_name);
                Console.Read();
            }        
    }
