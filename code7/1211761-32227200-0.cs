    public class MyReqAttribute : RequiredAttribute
    {
        public MyReqAttribute(string errorID)
        {
            // your logic here fill your error message as you want.
            this.ErrorMessage = Translation.Item.Find(x => x.Id == errorID 
                && x.Type == "Required").Text;           
        }
    }
