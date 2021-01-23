    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    
    namespace ConsoleSandbox
    {
        class Program
        {
            public static void Main()
            {
                var config = new MapperConfiguration(
                    cfg => cfg.CreateMap<StudentDto, Student>());
                var mapper = config.CreateMapper();
                var studentDtos = new[]
                {
                    new StudentDto
                    {
                        Id = "1",
                        StudentContacts = new[]
                        {
                            new StudentContact { ContactName = "Dan", PrimaryContactNo = "123" },
                            new StudentContact { ContactName = "Stan", PrimaryContactNo = "456" },
                        }.ToList()
                    },
                    new StudentDto
                    {
                        Id = "2",
                        StudentContacts = new[]
                        {
                            new StudentContact { ContactName = "Foo", PrimaryContactNo = "789" },
                            new StudentContact { ContactName = "Bar", PrimaryContactNo = "101112" },
                        }.ToList()
                    },
                }.ToList();
                var driverActivationResponse = mapper.Map<List<Student>>(studentDtos);
                Console.WriteLine($"Contacts Count: {driverActivationResponse.Count}");
                Console.ReadKey();
            }
        }
    
        public class StudentDto
        {
            public string Id { get; set; }
            public List<StudentContact> StudentContacts { get; set; }
    
            public StudentDto()
            {
                if (StudentContacts == null) StudentContacts = new List<StudentContact>();
            }
        }
    
        public class Student
        {
            public string Id { get; set; }
            public List<StudentContact> StudentContacts { get; set; }
    
            public Student()
            {
                if (StudentContacts == null) StudentContacts = new List<StudentContact>();
            }
        }
    
        public class StudentContact
        {
            public string ContactName { get; set; }
            public string PrimaryContactNo { get; set; }
        }
    }
