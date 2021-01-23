    //in domain namespace
    public interface INameChangeStrategy {
        public void ChangeName(Project project, string name);
    } 
    
    //in general use namespace
    public class DefaultNameChangeStrategy : INameChangeStrategy {
        public void ChangeName(Project project, string name) {
            if (project.IsPublished()) throw new InvalidOperationException("Not allow to change name after published");
            project.setName(name);
        }
    }
    //in admin use namespace
    public class AdminNameChangeStrategy : INameChangeStrategy {
        public void ChangeName(Project project, string name) {
            project.setName(name);
        }
    }
