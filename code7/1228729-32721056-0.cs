    public class UserPhotoInfo
    {
        public string Username { get; set; }
        public string PhotoPath { get; set; }
    }
    
    var userNphotoValues = new List<UserPhotoInfo>();
    userNphotoValues.Add(new UserPhotoInfo() { Username = stringAVal, PhotoPath = stringBVal });
    
    dataGridView.DataSource = userNphotoValues;
