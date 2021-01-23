    public abstract class DBVolumetricObject
    {
        public int Id { get; set; }
    }
    
    public class Material : DBVolumetricObject
    {
        public int Design_Id { get; set; }
        public virtual MaterialDesign MaterialDesign{ get; set; }       
    }
    
    public class MaterialDesign : IDBDesign
    {
       ...
       public virtual List<Material> Materials { get; set; }
    } 
