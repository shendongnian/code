    public class Sample : IEnumerable, IEnumerable<Giraffe>, IEnumerable<Pigeon>
    {
        IEnumerator<Giraffe> IEnumerable<Giraffe>.GetEnumerator()
        {
            return null;
        }
        IEnumerator<Pigeon> IEnumerable<Pigeon>.GetEnumerator()
        {
            return null;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return null; //your logic for the enumerator
        }
    }
