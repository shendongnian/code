    public class UserProfileDTO
    {
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public ICollection<AddressDTO> Addresses { get; set; }
    }
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserProfileDTO Profile { get; set; }
    }
    Mapper.CreateMap<User, UserDTO>();
    Mapper.CreateMap<Profile, UserProfileDTO>();
