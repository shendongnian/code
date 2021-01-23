	using UnityEngine;
	using System.Collections;
	using CielaSpike; //include ninja threads
	public class MyAsyncCompression : MonoBehaviour {
		public void ZipIt(){
			//ready data for commpressing - you will not be able to use any Unity functions while inside the asynchronous coroutine
			this.StartCoroutineAsync(MyBackgroundCoroutine()); // "this" means MonoBehaviour
		}
		IEnumerator MyBackgroundCoroutine(){
			//Call CompressFolder() here
			yield return null;
		}
		private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset) {
			/*...
			 *... 
			  ...*/
		}
	}
