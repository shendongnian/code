        class Program
        {
            static void Main(string[] args)
            {
                OptionFeature optionFeature = new OptionFeature();
                optionFeature.material = new Material();
                Fabric fabric = (Fabric)optionFeature.material;
                
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
