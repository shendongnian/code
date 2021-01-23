    public static List<School> GetAllSchools()
            {
                List<School> schools = new List<School>
            {
                new School
                {
                     Id =1 ,
                      Name = "1",
                       Classrooms = new List<Classroom> { new Classroom { Id = 1, Name = "1"  }, new Classroom { Id = 2, Name = "2"  } }
                },
                new School
                {
                    Id =2 ,
                      Name = "2",
                       Classrooms = new List<Classroom> { new Classroom { Id = 3, Name = "3"  }, new Classroom { Id = 4, Name = "4"  } }
                      
                }
            };
    
                return schools;
            }      
