    public interface ISetColor
    {
         public Color color { get; set; }
    }
    public class ImageSetColor : MonoBehaviour, ISetColor
    {
        
        public Image m_Image
        public Color color { get {return m_Image.color;} set { m_Image.color = value}
        
    }
    public class MaterialSetColor : MonoBehaviour, ISetColor
    {
        
        public Material m_Material
        public Color color { get {return m_Material.color;} set { m_Material.color = value}
        
    }
