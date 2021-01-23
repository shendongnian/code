    [ExecuteInEditMode]
    public class SpriteToScreen : MonoBehaviour {
	public float sprw = 256f;
	public float sprh = 256f;
	float unitspp = 100f;
	public float scrw = 0f;
	public float scrh = 0f;
	public float aspect = 0f;
	public float spr_aspect = 1f;
	public float factorY = 0.017578125f;
	public void Update(){
		scrw = Screen.width;
		scrh = Screen.height;
		aspect = scrw / scrh;
		unitspp = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
		sprw = this.GetComponent<SpriteRenderer>().sprite.bounds.size.x * unitspp;
		sprh = this.GetComponent<SpriteRenderer>().sprite.bounds.size.y * unitspp;
		spr_aspect = sprw / sprh;
		this.transform.localScale = new Vector3( (1152f / sprh * aspect) / spr_aspect,
			1152f / sprh, 
			1 );
	}
    }
