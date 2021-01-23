            AutoMapper.Mapper.CreateMap<Student, StudentDto>()
               .ForMember(a => a.StudentContacts, b => b.ResolveUsing(c => c.StudentContacts));
            var map = Mapper.Map<StudentDto>(new Student
            {
                Id = "100",
                StudentContacts = new List<StudentContact>
                {
                    new StudentContact{ContactName = "test",PrimaryContactNo = "tset"}
                }
            });
