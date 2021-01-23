    public class Skill{
     public string SkillName{get; set;}
     public virtual IList<Teacher> Teachers{get;set;}
    }
    protected override void Seed(Ability_Examen_ASP.Models.AbilityDbContext context){
     if (!context.Skills.Any())
        {
            
			
			if(!context.Skills.Any() && !context.Teachers.Any()){
				context.Skills.Add(new Models.Skill{ SkillName = "PHP", Teachers = new List<Teacher>{new Teacher{FirstName = "Joris",
                LastName = "Hens",
                Campus = "Kruidtuin",
                Password = "testpass",
                Email = "Joris.Hens@thomasmore.be"}} },
     
         );
     // repeat for other skills followed by list of teachers
			  }
			
			context.SaveChanges();
			
          }
    }
