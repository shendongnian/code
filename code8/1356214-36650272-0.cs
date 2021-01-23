    public class PlannedMaterial
    {
        public PlannedMaterial(ScheduleRow s, Material m){
            ScheduleRow = s;
            Material = m;
        }
        public int Id { get{return _s.Id; } set{_s.Id = value;} }
        public string Name { get{return _m.Name; } set{_m.Name = value; }
        public int SequenceNo { get{return _s.SequenceNo; } set{_s.SequenceNo = value; } 
    
        Material _m{ get; set; }
        ScheduleRow _s{ get; set; }
    }
