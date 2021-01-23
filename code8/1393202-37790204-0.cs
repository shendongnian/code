    public class SolarSystem : IEnumerable<Planet>
    {
        public IEnumerator<Planet> GetEnumerator()
        {
            yield return mercury;
            yield return venus;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
