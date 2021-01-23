    var myDto = new MyDto
    {
        studentInfo = new MyModel.StudentInfo
        {
            Others = new List<AnotherDTO[]>
            {
                new[] 
                {
                   new AnotherDTO { Name = "a" },
                   new AnotherDTO { Name = "b" }
                },
                new[] 
                {
                   new AnotherDTO { Name = "x" },
                   new AnotherDTO { Name = "y" }
                }
            }
        }
        var model = new MyModel
        {
            studentInfo = new MyModel.StudentInfo
            {
                Others = dto.StudentInfo.Others
                   .Select(otherDtoArray =>
                        otherDtoArray
                          .Select(otherDto => new MyModel.Other {Name = otherDto.Name})).ToList()
            }
