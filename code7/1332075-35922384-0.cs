    public class AcadLocs : Locs // or List<AcadLoc> ? 
    {
        public AcadLoc Get_By_Id(int id)
        {
            return this.OfType<AcadLoc>().SingleOrDefault(n => n.Id == id);
        }
    }
