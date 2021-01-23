    public interface ISetColor
    {
         public Color color { get; set; }
    }
    public class ImageSetColor : MonoBehaviour, ISetColor
    {
        
        public Image m_Image
        public void color { get {return m_Image.color;} set { m_Image.color = value}
        
    }
