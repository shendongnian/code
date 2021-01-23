    public class ExampleClass : MonoBehaviour {
        // Load a .jpg or .png file by adding .bytes extensions to the file
        // and dragging it on the imageAsset variable.
        public TextAsset imageAsset;
        public void Start() {
            // Create a texture. Texture size does not matter, since
            // LoadImage will replace with with incoming image size.
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imageAsset.bytes);
            GetComponent<Renderer>().material.mainTexture = tex;
        }
    }
