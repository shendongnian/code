    class MaterialSetter : MonoBehaviour{
        public void SetMaterial(string materialName)
        {
            Material mat = Resources.Load(materialName, typeof(Material)) as Material;
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = newMaterial;
        }
    }
