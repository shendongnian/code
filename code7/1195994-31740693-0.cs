    public interface IHasText
    {
      string GetPrivateText();
    }
    public class GetString : IHasText
    {
      private string myText = "this is the string that i need to get";
      
      string IHasText.GetPrivateText()
      {
        return myText;
      }
    }
    var val = new GetString();
    var asInterface = (IHasText)val;
    string text = asInterface.GetPrivateText();
