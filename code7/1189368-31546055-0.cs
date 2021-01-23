    class Car
      : ICustomizeCar
    {
       ICustomizeCar::Color {get;set;} 
    
        static Car MakeCustomCarWithColor(string color)
        {
            return new Car(c => c.Color = color);
        }
        public Car(Action<ICustomizeCar> customization)
        {
            customization(this);
            Console.WriteLine(myCustom.Color);
        }
    
        public interface ICustomizeCar
        {
            string Color { get; set; }
        }
    }
