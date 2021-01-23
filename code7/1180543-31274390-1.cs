    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    [System.Web.Script.Services.ScriptService]
    public class FoamServices : System.Web.Services.WebService {
    public FoamServices () {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string[] GetFoamNames(string term) {
        List<Foam> foams = Foam.Read(term);
        string[] foamNames = new string[foams.Count];
        for(int i = 0; i < foams.Count; i++)
        {
            foamNames[i] = foams[i].FoamName;
        }
        return foamNames;
    }
    
    }                        
