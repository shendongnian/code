    public class Knockback : MonoBehaviour {
		public float explosionStrength = 10.0f;
		
		void OnTriggerEnter (Collider target_){
		Vector3 forceVec = -target_.GetComponent<Rigidbody> ().velocity.normalized * explosionStrength;
			target_.GetComponent<Rigidbody>().AddForce(forceVec,ForceMode.Force);
		}
	}
