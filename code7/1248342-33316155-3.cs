         interface IUnit
        {
            event EventHandler<ResourceGeneratedEventArgs> ResourceGenerated;
            void RegisterUnit(IUnit inputUnit);
            string Name { get; }
        }
        class Unit : IUnit
        {
            IUnit mInputUnit;
            public event EventHandler<ResourceGeneratedEventArgs> ResourceGenerated;
            public string Name { get; private set; }
            public Unit(string name)
            {
                this.Name = name;
            }
            public void RegisterUnit(IUnit inputUnit)
            {
                this.mInputUnit = inputUnit;
                this.mInputUnit.ResourceGenerated += mInputUnitResourceGenrated;
            }
            void mInputUnitResourceGenrated(object sender, ResourceGeneratedEventArgs inputResource)
            {
               //take the input resorce. pocess it & fire the event;
                //I'm just adding 1 to it as sample
                int outputResource = inputResource.Resource + 1;
                Console.WriteLine("Unit {0}, input {1} ", this.Name, inputResource.Resource, outputResource);
               
                OnResourceGenerated(outputResource);
            }      
     
            protected virtual void OnResourceGenerated(int outputResource)
            {
                Console.WriteLine("Unit {0}, output {1}", this.Name,  outputResource);
                 if (ResourceGenerated != null)
                    ResourceGenerated(this, new ResourceGeneratedEventArgs(outputResource));
            }
        }
        public class ResourceGeneratedEventArgs : EventArgs
        {
            public ResourceGeneratedEventArgs(int resource)
            {
                Resource = resource;
            }
            public int Resource { get; private set; }
        } 
         /// <summary>
         /// This is just to start the process here, Nothing great here 
         /// </summary>
         interface IInitiatorUnit : IUnit
         {
            void  GenerateResource(int initialValue);
         }
        class InitiatorUnit : Unit, IInitiatorUnit
        {
            //prevents the cycle from going on & on
            bool resetFlag;
            public InitiatorUnit(string name):base(name)
            {
            }
            public void GenerateResource(int initialValue)
            {
                resetFlag = false;
                Console.WriteLine("Initiating Unit {0} value {1}", this.Name, initialValue);
                OnResourceGenerated(initialValue);
            }
            protected override void OnResourceGenerated(int outputResource)
            {
                //Dont raise the event. if the cycle has completed
                if (resetFlag == false)
                {
                    resetFlag = true;
                    base.OnResourceGenerated(outputResource);
                }
                else
                {
                    //do nothing, cycle has completed
                    Console.WriteLine("Unit {0}, Cycle complete", this.Name);
                }
            }
        }
