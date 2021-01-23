    class MaterialSetter : MonoBehaviour{
        public void SetMaterial(Material newMaterial)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = newMaterial;
        }
    }
