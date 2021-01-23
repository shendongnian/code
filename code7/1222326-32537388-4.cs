    public class Car
    {
        .....
        public override string ToString()
        {
            return string.Format("{{ Number = \"{0}\", Brand= \"{1}\", Model = \"{2}\", Kilometers = \"{3}\" }}",
                                  this.number, this.brand, this.model, this.kilometers);
    // if using C# 6.0 you can use string interpolation instead.
    // return $"{{ Number = \"{this.number}\", Brand= \"{this.brand}\", Model = \"{this.model}\", Kilometers = \"{this.kilometers}\" }}";
        }
    }
