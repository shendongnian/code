    public IInfoCard CreateNewInfoCard(string category)
    {
        return new InfoCard();
    }
    
    public interface IInfoCard
    {
        int foo { get; set; }
    }
    
    public interface IInfoCardFactory : IInfoCard
    {
        IInfoCard CreateNewInfoCard(string category);
        IInfoCard CreateInfoCard(string initialDetails);
        string[] CategoriesSupported { get; }
        string GetDescription(string category);
    }
    
    public class InfoCard : IInfoCardFactory
    {
        public IInfoCard CreateNewInfoCard(string category)
        {
            throw new NotImplementedException();
        }
    
        public IInfoCard CreateInfoCard(string initialDetails)
        {
            throw new NotImplementedException();
        }
    
        public string[] CategoriesSupported
        {
            get { throw new NotImplementedException(); }
        }
    
        public string GetDescription(string category)
        {
            throw new NotImplementedException();
        }
    
        public int foo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
