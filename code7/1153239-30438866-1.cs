    public class UserUI 
    {
         UserDTO _userDto;
         UserUI(UserDTO userDto)
         {
             _userDto = userDto;
         }
         public string Name
         {
            get{return IsAfter_21_hour ? "The user as gone home : _userDto.Name;}
         }
    }
