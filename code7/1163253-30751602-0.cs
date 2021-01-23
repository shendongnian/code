        public abstract class Vehicle
        {
            public int Id { get; set; }
            public virtual void SaveCar()
            {
                // save Id
            }
        }
        public class Car : Vehicle
        {
            public string Type  { get; set; }
            public string Name { get; set; }
            public override void SaveCar()
            {
                base.SaveCar();
                // Save type & name
            }
        }
