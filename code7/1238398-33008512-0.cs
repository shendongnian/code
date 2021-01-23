        using Parse;
        using System.Threading.Tasks;
        
        public class MainMenuScript : MonoBehaviour {
    
    	ParseObject parseObjToUpdate; 
        private bool hasUpdatedParse;
        public string myCurrentChalID;
    
        void Start()
        {
            hasUpdatedParse = false;
        	var query = ParseObject.GetQuery("ChallengeStatus")
            	.WhereEqualTo("challengeID", myCurrentChalID);
            	query.FirstAsync().ContinueWith(t =>
                 {
            		parseObjToUpdate = t.Result;
            		print (parseObjToUpdate.ObjectId); // to debug that something is happening and it's the right object
       			  });
        }
    
        void Update ()
        {
           if (parseObjToUpdate != null && !hasUpdatedParse)
            {
            	parseObjToUpdate["playerTurn"] = PlayerPrefs.GetString("opponentID");
                parseObjToUpdate.SaveAsync();
                hasUpdatedParse = true;
            }
        }
