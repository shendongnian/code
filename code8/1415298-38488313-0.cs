	namespace Stories
	{
	    public class ControllersNames {
	        public const string AllStories = "AllStories";
	        public const string MySubmissions = "MySubmissions";
	    }
	    public class ActionsNames
	    {
	        #region AllStories
	        public const string AllStories_ReadLater = "ReadLater";
	        public const string AllStories_PlanToUse = "PlanToUse";
	        #endregion
	        #region MySubmissions
	        public const string MySubmissions_ReadLater = "ReadLater";
	        public const string MySubmissions_PlanToUse = "PlanToUse";
            //same action but with different paramaters below
	        public const string MySubmissions_PlanToReUse = "PlanToUse"; 
	        public const string MySubmissions_Store = "Store";
	        #endregion
	    }
	}
