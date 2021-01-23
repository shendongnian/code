    public class ReadText: MonoBehaviour {
       public TextAsset textFile; 
       //text file to be read is assigned from the Unity inspector pane after selecting 
       //the object for which this C# class is attached to
	   string Start(){
		   string text = textFile.text;  //this is the content as string
		   Debug.Log(text);
		   return text;
	   }
    }
