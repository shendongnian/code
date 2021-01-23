    //move all the db access stuff here
	public class Db
	{
        //assuming single drone is returned
		public Drone GetDrone(int id)
		{	
            //do SingleOrDefault or Where depending on the needs
	        Drone drone = GetDrones().SingleOrDefault(drones => drones.iddrones == id);			
			return drone;
		}
		public IQueryable<Drone> GetDrones()
		{
	        var drone = db.drones.Select(d => new DroneDTO
	        {
	            iddrones = d.iddrones,
	            //more stuff
	        });
			return drone;
		}
	}
