    public interface INameChangeCheckStrategy {
        public CanChangeName(Project project, string name);
    } 
    //in general use namespace
    public class DefaultNameChangeCheckStrategy : INameChangeCheckStrategy {
        public void ChangeName(Project project, string name) {
            if (project.IsPublished()) throw new InvalidOperationException("Not allow to change name after published");
            //other check logic, i.e. regex match
        }
    }
    
    public class Project
    {
        private INameChangeCheckStrategy _nameChangeAbilityStrategy;
        ...
        public void ChangeName(string newName)
        {
             _nameChangeAbilityStrategy.CanChangeName(this, newName);
             name = newName;
        }
    }
