    public interface IFBConnect {
        public FBData GetFBData();
        public bool PostFBData();
        //etc. etc
    }
    public class FacebookProvider : IFBConnect {
        public FBData GetFBData() {
            //call the webservice
            //parse the JSON to your model object
            return FBData
        }
    }
