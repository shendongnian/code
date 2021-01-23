    public class ChangeAlpha : MonoBehaviour {
    public Renderer Renderer;
    private Material _material;
	// Use this for initialization
	void Start () {
        _material = Renderer.material;
        StartCoroutine("ChangeAlphaSlowly");
	}
    private IEnumerator ChangeAlphaSlowly()
    {
        var increaseAmount = 0f;
        var _color = new Color(0, 0, 1, 0);
        for (int i = 0; i < 10; i++)//ten step 
        {
            increaseAmount += 0.1f;
            _material.color = new Color(0, 0, 1, increaseAmount);          
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
