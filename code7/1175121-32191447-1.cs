    class Person{
    int Id{get;set;}
    string Name{get;set}
    }
    
    class Student{
    int Id{get;set;}
    string StudentNo{get;set;}
    Person Person{get;set;}
    
    public class StudentMap : EntityTypeConfiguration<Student>
        {
            public StudentMap()
            {
                // Primary Key
                HasKey(t => t.Id);
    
               
                // Table & Column Mappings
                ToTable("Students");
                Property(t => t.Id).HasColumnName("StudentId");
    
               // Relationships
                HasRequired(t => t.Person)                
                    .HasForeignKey(d => d.PersonId);
      }
    }
