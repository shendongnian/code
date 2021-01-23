    public class FieldDTO
    { 
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TeacherDTO> Teachers { get; set; }
    public FieldDTO()
    {
        Teachers = new List<TeacherDTO>();
    }
    }
    public class TeacherDTO {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName => Email;
    }
    public class AppUserDTO : TeacherDTO
    {
    public List<FieldDTO> Fields { get; set; }
    public AppUserDTO()
    {
        Fields = new List<FieldDTO>();
    }
    }
