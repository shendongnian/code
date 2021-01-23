    public class VehiclesViewModel
    {
        public List<vehicles> Vehicles { get; private set; }
    
        public void Initalize()
        {
          this.Vehicles  = new List<vehicles>();
    
            var vehicle = new vehicles
                           {
                               vehID = 1,
                               vehDescription = "firstDescription",
                           };
            var stepsList = new stepsList
                            {
                                steps = "firstStep",
                            };
            var movChannel = new movChannels
                              {
                                  name = "firstChannel",
                              };
            var criteria = new criterias
                            {
                                values = 0.5,
                                time = 0.5
                            };
            
            movChannel.criteria.Add(criteria);
            stepsList.stepChannelsCriteria.Add(movChannel);
            vehicle.vehValCriteria.Add(stepsList);
            
            this.Vehicles.Add(vehicle);
        }
    }
