        interface IUnit
        {
            Resource ProcessResource(Resource inputResource);
            string Name { get; }
        }
        class Unit : IUnit
        {
            public string Name { get; private set; }
            public Unit(string name)
            {
                this.Name = name;
            }
            public Resource ProcessResource(Resource inputResource)
            {
                //take the input resorce. pocess it & fire the event;
                //I'm just adding 1 to it as sample
                int outputResource = inputResource.Value + 1;
                Console.WriteLine("Unit {0}, input {1} ", this.Name, inputResource.Value);
                Console.WriteLine("Unit {0}, output {1} ", this.Name, outputResource);
                return new Resource(outputResource);
            }
        }
        class WorkFlow
        {
            IUnit[] mUnits;
            public WorkFlow(IUnit[] units)
            {
                this.mUnits = units;
            }
            public Resource Execute(Resource initiatingResource)
            {
                Resource result = initiatingResource; // initialise result with the input of the cycle.
                for (int i = 0; i < mUnits.Length; i++)
                {
                    // the result is passed as input. 
                    //IUnit.ProcessResource function gives back a new result which is encached as input for subsequent resource
                    result = mUnits[i].ProcessResource(result);
                }
                return result; // after all are processed, 
            }
        }
        public class Resource
        {
            public Resource(int resourceValue)
            {
                Value = resourceValue;
            }
            public int Value { get; private set; }
        }  
