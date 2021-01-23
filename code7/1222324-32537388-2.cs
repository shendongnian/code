    public class Car
    {
        .....
        public override string ToString()
        {
            return string.Format("{{ Number = \"{0}\", Brand= \"{1}\", Model = \"{2}\", Kilometers = \"{3}\" }}",
                                  this.number, this.brand, this.model, this.kilometers);
        }
    }
