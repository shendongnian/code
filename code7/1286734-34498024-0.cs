      public abstract class Position
      {
        public abstract List<int> ListOfPhones();
      }
    
      public class Employer
      {
        public virtual IList<Position> CurrentPositions { get; set; }
      }
    
      public class Manager : Employer
      {
        public Manager(List<Position> positions)
        {
          this.CurrentPositions = positions;
        }
    
        public IEnumerable<int> GetNumbers()
        {
          foreach (Position position in this.CurrentPositions)
            foreach (var number in position.ListOfPhones())
              yield return number;
    
        }
      }
