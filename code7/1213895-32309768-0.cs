    public class ExerciseRecord
    {
        public int ExerciseRecordId { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; } 
        public virtual Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
        public virtual Workout Workout { get; set; }  
        public int WorkoutId { get; set; }
    }
