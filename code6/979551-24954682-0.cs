	using UnityEngine;
	using System.Collections;
	public class Tester : MonoBehaviour {
		[SerializeField] string formula=@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}";
		Texture texture=null;
		IEnumerator Start() {
			WWW www=new WWW("http://chart.apis.google.com/chart?cht=tx&chl="+formula);
			yield return www;
			texture=www.texture;
		}
		void OnGUI() {
			if(texture != null)
				GUI.DrawTexture(new Rect(0,0,texture.width,texture.height), texture);
		}
	}
