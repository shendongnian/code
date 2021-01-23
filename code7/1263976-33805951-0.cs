    public class ActivityGroup
    {
        public string Fecha {get; set;}
        public IEnumerable<Activity> Activities {get; set;}
    }
    
    public class Activity
    {
        public string Actividades {get; set;}
        public IEnumerable<string> NombreEmpleado {get; set;}
    }
    
