	using UnityEngine;
	using System.Linq;
	public class Test : MonoBehaviour {
		[SerializeField] Vector3[] spawnPoints;
		[SerializeField] GameObject spawnObject;
		void Start(){
			InitRandom ();
		}
		void InitRandom(){
			System.Random rnd = new System.Random ();
			Vector3[] items = (
				from i in spawnPoints
				orderby rnd.Next()
				select i
			).ToArray();
			
			foreach (Vector3 v in items) {
				Instantiate(spawnObject, v, Quaternion.identity);
			}
		}
	}
