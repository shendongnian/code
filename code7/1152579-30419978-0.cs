    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<result>" +
                       "<record>" +
                           "<field name=\"donor_id\" id=\"donor_id\" value=\"9879\" />" +
                           "<field name=\"first_name\" id=\"first_name\" value=\"Trix5647\" />" +
                           "<field name=\"last_name\" id=\"last_name\" value=\"Rabbit657\" />" +
                           "<field name=\"email\" id=\"email\" value=\"test@asd..com\" />" +
                           "<field name=\"business_phone\" id=\"business_phone\" value=\"\" />" +
                           "<field name=\"mobile_phone\" id=\"mobile_phone\" value=\"\" />" +
                           "<field name=\"home_phone\" id=\"home_phone\" value=\"\" />" +
                           "<field name=\"address\" id=\"address\" value=\"Street S.W. \" />" +
                           "<field name=\"address2\" id=\"address2\" value=\"\" />" +
                           "<field name=\"city\" id=\"city\" value=\"Quaker\" />" +
                           "<field name=\"state\" id=\"state\" value=\"PA\" />" +
                           "<field name=\"zip\" id=\"zip\" value=\"1234\" />" +
                           "<field name=\"country\" id=\"country\" value=\"USA\" />" +
                       "</record>" +
                      "<record>" +
                           "<field name=\"donor_id\" id=\"donor_id\" value=\"9879\" />" +
                           "<field name=\"first_name\" id=\"first_name\" value=\"Trix5647\" />" +
                           "<field name=\"last_name\" id=\"last_name\" value=\"Rabbit657\" />" +
                           "<field name=\"email\" id=\"email\" value=\"test@asd..com\" />" +
                           "<field name=\"business_phone\" id=\"business_phone\" value=\"\" />" +
                           "<field name=\"mobile_phone\" id=\"mobile_phone\" value=\"\" />" +
                           "<field name=\"home_phone\" id=\"home_phone\" value=\"\" />" +
                           "<field name=\"address\" id=\"address\" value=\"Street S.W. \" />" +
                           "<field name=\"address2\" id=\"address2\" value=\"\" />" +
                           "<field name=\"city\" id=\"city\" value=\"Quaker\" />" +
                           "<field name=\"state\" id=\"state\" value=\"PA\" />" +
                           "<field name=\"zip\" id=\"zip\" value=\"1234\" />" +
                           "<field name=\"country\" id=\"country\" value=\"USA\" />" +
                       "</record>" +
                   "</result>";
                List<dp_donorsearch> list = dp_donorsearch.Load(input);
            }
            public class dp_donorsearch
            {
                public string donor_id { get; set; }
                public string first_name { get; set; }
                public string last_name { get; set; }
                public string email { get; set; }
                public string business_phone { get; set; }
                public string mobile_phone { get; set; }
                public string home_phone { get; set; }
                public string address { get; set; }
                public string address2 { get; set; }
                public string city { get; set; }
                public string state { get; set; }
                public string zip { get; set; }
                public string country { get; set; }
                public static List<dp_donorsearch> Load(string input)
                {
                    List<dp_donorsearch> list = new List<dp_donorsearch>();
                    XDocument doc = XDocument.Parse(input);
                    var listDict = doc.Descendants("record").AsEnumerable()
                        .Select(x => new
                        {
                            dict = x.Descendants("field")
                                .GroupBy(y => y.Attribute("name").Value, z => z.Attribute("value").Value)
                                .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                        });
                    foreach(var dict in listDict)
                    {
                        dp_donorsearch newDp = new dp_donorsearch();
                        list.Add(newDp);
                        newDp.donor_id = dict.dict["donor_id"];
                        newDp.first_name = dict.dict["first_name"];
                        newDp.last_name = dict.dict["last_name"];
                        newDp.email = dict.dict["email"];
                        newDp.business_phone = dict.dict["business_phone"];
                        newDp.mobile_phone = dict.dict["mobile_phone"];
                        newDp.home_phone = dict.dict["home_phone"];
                        newDp.address = dict.dict["address"];
                        newDp.address2 = dict.dict["address2"];
                        newDp.city = dict.dict["city"];
                        newDp.state = dict.dict["state"];
                        newDp.zip = dict.dict["zip"];
                        newDp.country = dict.dict["country"];
                    }
                    return list;
                }
     
            }
        }
    }
    ​
