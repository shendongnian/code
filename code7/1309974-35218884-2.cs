    public class BaseCar : IEquatable<ICar>, IComparable<ICar>
    {
        /// [...]
    }
    public void Test(BaseCar car1, BaseCar car2)
    {
        car1.Equals(car2);
        car2.CompareTo(car2);
    }
