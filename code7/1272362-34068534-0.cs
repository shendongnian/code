    using System.Web.Script.Serialization;
    var jss = new JavaScriptSerializer();
    var dict = jss.Deserialize<Dictionary<string,dynamic>>(jsonText);
    Console.WriteLine(dict["Brands"]); /
    Console.WriteLine(dict["Products"]); 
