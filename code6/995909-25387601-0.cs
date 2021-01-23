    using UnityEngine;
    using System.Collections;
    public class ChangeFont : MonoBehaviour {
		public UILabel label; 
		public Font otherFont;
		IEnumerator Start() {
			label.text = "This is a bit of text"; //show text
			yield return new WaitForSeconds(2f); //wait 2 seconds
			label.trueTypeFont = otherFont; //change font
		}
	}
