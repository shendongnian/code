    public class Pets :IEnumerable, IEnumerable<Giraffe>, IEnumerable<Pigeon>
            {
                IEnumerator<Giraffe> IEnumerable<Giraffe>.GetEnumerator()
                {
                    return null;
                }
                IEnumerator<Pigeon> IEnumerable<Pigeon>.GetEnumerator()
                {
                    return null;
                }
    
                public IEnumerator GetEnumerator()
                {
                    throw new NotImplementedException();
                }
            }
