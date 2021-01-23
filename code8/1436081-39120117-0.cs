    public interface IPersonModel
    {
        ICompany Company { get; set; }
        IDog Dog { get; set; }
        ICar Car { get; set; }
    }
    public class DogModel: IDog
    {
        public string Name { get; set; }
        public IBreed Breed { get; set; }
    }
    public class BreedModel : IBreed
    {
        public string Attributes { get; set; }
        public void GetBreedData()
        {
           // ...
        }
    }
    public interface IPersonManager
    {
        Task<IEnumerable<IPersonModel> GetPersonData();
    }
