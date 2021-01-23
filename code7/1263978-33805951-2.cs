    public class ActivityGroup
    {
        public DateTime Fecha {get; set;}
        public IEnumerable<Activity> Activities {get; set;}
    }
    
    public class Activity
    {
        public IEnumerable<Activity> Actividades {get; set;}
        public string NombreEmpleado {get; set;}
    }
    
