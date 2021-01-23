    public class mycontroller: ApiController
      {
        
        public string Get()
        {
          var testArray = new List<clienti>();
          testArray.Add(new clienti() {nome = "Mark", cognome = "Reed", email =    "mark.reed@test.com"});
           return testArray ;
        }
