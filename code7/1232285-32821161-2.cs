    public class MyRows
    {
        public string Key { get; set; }
        public int Id { get; set; }
        public object Val { get; set; }
    }
    public abstract class BasicDTO
    {
        public int? Id { get; private set; }
     
        public PropertyInfo[] PropertyDTO;
        protected Type myType;
        public BasicDTO()
        {
            Load();
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            PropertyDTO = myType.GetProperties(flags);
        }
    }
    public class CustomerDTO : BasicDTO
    {
        public string Surname { get; set; }
        public string Phone { get; set; }
        public CustomerDTO() { }
        protected override void Load()
        {
            myType = typeof(CustomerDTO);         
        }
    }
