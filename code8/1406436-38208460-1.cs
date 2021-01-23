    public class ModelFactory
    {
        public StudentViewModel Create(model )
        {
            return new StudentViewModel
            {
               Id = model.Id;
               Name = model.Name;
            }
        }
    }
