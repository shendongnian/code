    public class PlatanoJson  //this is first class where arraylist is     declared{
    public string question { get; set; }
    public string correctans { get; set; }
    public bool typeofans { get; set; }
    public int indexofque { get; set; }
    public List<string> DiffAns { get; set; }
    }
    
     public class JsonSerializationController : ApiController
      {
    [Route("getjsondata")]
    public string jsonDataToSerialize()
    {
    var list= new List<string>();
    list.Add("your stuff1");
    list.Add("your stuff2");
    list.Add("your stuff3");
        var game = new PlatanoJson {
               question = "What is your education?",
            correctans = "MCA",
            typeofans = true,
            indexofque = 3,
            DiffAns = list;  
        };
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(game);
        var dresult = Newtonsoft.Json.JsonConvert.DeserializeObject<PlatanoJson>        (......................
    }
 }
