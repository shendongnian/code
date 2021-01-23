    public enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    
    public class Employee
    {
        public DayOfWeek DayOff;
    }
    
    public class DayOffAllocator
    {
        Random _random = new Random();
        DayOfWeek[] _daysOff = (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));
        List<DayOfWeek> _availableDaysOff = new List<DayOfWeek>();
    
        public void AllocateDayOff(Employee employee)
        {
            if (!_availableDaysOff.Any())
                _availableDaysOff = new List<DayOfWeek>(_daysOff);
            int index = _random.Next(_availableDaysOff.Count);
            employee.DayOff = _availableDaysOff[index];
            _availableDaysOff.RemoveAt(index);
        }
    }
