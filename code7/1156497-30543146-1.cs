        class Program
        {
            static void Main(string[] args)
            {
                OptionFeature optionFeature = new OptionFeature();
                optionFeature.material = new Material();
                Fabric fabric = (Fabric)optionFeature.material;
                List<Material> materials = new List<Material>();
                List<Fabric> fabrics = materials.Select(x => (Fabric)x).ToList();
                
            }
        }
        public class OptionFeature
        {
            public Material material {get;set;}
        }
        public class Material
        {
        }
        public class Fabric : Material
        {
        }​
