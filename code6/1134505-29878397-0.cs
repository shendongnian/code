    public interface IHand
    {
        void Shake(IHand otherHand);
    }
    
    public class Hand : IHand
    {
        public void Shake(IHand otherHand)
        {
            Console.WriteLine("Shook the other hand");
        }
    }
