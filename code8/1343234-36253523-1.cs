    [ResponseType(typeof(UserDto))]
    public IHttpActionResult User(string userId){
  
       // retrive user from db
       
       var userDto = Mapper.Map<UserDto>(dbUser);
       
       if(condition){
          userDto.Message = "the message";
          userDto.Status = "the status";
       }
       return Ok(userDto);
    }
