       public interface IInformation
            {
                string name { get; set; }
                string description { get; }
                string age { get; set; }
            }
        
            public class myClass : IInformation
            {
                public string age
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
        
                public string description
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }
        
                public string name
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
