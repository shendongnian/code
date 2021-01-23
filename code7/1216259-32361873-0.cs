    public class WorkOrderJson<T>
    {
        public Geometry<T> geometry { get; set; }
        
        public WorkOrderJson<List<T>> Promote()
        {
            var temp = new WorkOrderJson<List<T>>();
            temp.geometry = geometry.Promote();
            return temp;
        }
    }
    public class Geometry<T>
    {
        public T coordinates { get; set; }
        public Geometry<List<T>> Promote()
        {
            var temp = new Geometry<List<T>>();
            temp.coordinates = new List<T>(){ coordinates };
            return temp;
        }
    }
    
    public List<WorkOrder<List<List<double>>>> Deserialize(string x)
    {
        try
        {
            return new JavaScriptSerializer().Deserialize<List<WorkOrderJson<List<List<double>>>>>(x);
        }
        catch(InvalidOperationException ex)
        {
            return new JavaScriptSerializer().Deserialize<List<WorkOrderJson<List<double>>>>(x).Select(workOrder => workOrder.Promote());
        }
    }
