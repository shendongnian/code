    public class UserDTO
    {
        public string username { get; set; }
        public string email { get; set; }
        [XmlElement("whatever")] 
        public List<RoleDTO> role { get; set; }
    }
