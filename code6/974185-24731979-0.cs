    public class MachineFunction
    {
        public string Name { get; set; }
        public int Machines { get; set; }
    
        public ObservableCollection<ScaleUnit> ScaleUnits { get; set; }
    
        public MachineFunction()
        {
            ScaleUnits = new ObservableCollection<ScaleUnit>();
        }
    }
    
    public class ScaleUnit
    {
        public string Name { get; set; }
        public int Index { get; set; }
    
        public ScaleUnit(int index)
        {
            this.Index = index;
        }
    }
