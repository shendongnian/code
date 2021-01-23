    public class Athlete
    {
        public int Id {get; set;}
        public string Name {get; set;}
        //public virtual List<Workout> Workouts {get; set;}
        //public virtual List<TrainingPlan> TrainingPlans {get; set;}
    }
    public class Workout
    {
        public int Id {get; set;}
        public string Name {get; set;}
        //public virtual Athlete Athlete {get; set;}  //Athlete owner of the WO.
        //public virtual List<TrainingPlan> TrainingPlans {get; set;} //Plans where WO is.
    }
    public class TrainingPlan
    {
        public int Id {get; set;}
        public string Name {get; set;}
        //public virtual Athlete Athlete {get; set;}  //Athlete owner of this TP.
        //public virtual List<Workout> Workouts {get; set;} //Workouts in this plan.
    }
    
    public class ATrainingAthlete
    {
        public int Id {get; set;} 
        // connect the athlete
        public virtual Athlete Athlete {get; set;}
        // with its workouts
        public virtual List<Workout> Workouts {get; set;}
        // and training plans
        public virtual List<TrainingPlan> TrainingPlans {get; set;}
    }
    
