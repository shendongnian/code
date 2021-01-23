    public class StudentDataProvider : DataProviderBase
    {
         public StudentDto Insert(Student dto)
         { 
             var entity = new Student{ Name = dto.Name,Deparment= dto.Deparment};
             var addedItem = unitofwork.StudentReposiotry.Insert(entity);
             unitofWork.Save();
             dto.Id = addedItem.Id;
             return dto;
         }
         public StudentDto AddAndUpdate(StudentDto dto, StudentDto updateDto)
         { 
             var entity = new Student{ Name = dto.Name,Deparment= dto.Deparment};
             var update= new Student{ Name = updateDto.Name,Deparment= updateDto.Deparment};
             var addedItem = unitofwork.StudentReposiotry.Insert(entity);
             var updateItem=  unitofwork.StudentReposiotry.Update(update)
             unitofWork.Save();
             dto.Id = addedItem.Id;
             return dto;
         }
    }
     public class DataProvideBase
    {
        protected IUnitOfWork UnitOfWork;
        public DataProvideBase()
        {
            UnitOfWork = new UnitOfWork();
        }
    }
  
