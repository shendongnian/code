    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<View> views = new List<View>
            {
                new View() {CoordSys = new Plane(){Origin=new Origin(){x=1,y=0},Vector=0}, PartNums = new List<int> {1,2,3}}
                ,new View() {CoordSys = new Plane(){Origin=new Origin(){x=3,y=0},Vector=0}, PartNums = new List<int> {13,14,15}}
                ,new View() {CoordSys = new Plane(){Origin=new Origin(){x=2,y=0},Vector=0}, PartNums = new List<int> {4,5,6}}
                ,new View() {CoordSys = new Plane(){Origin=new Origin(){x=1,y=0},Vector=0}, PartNums = new List<int> {16,17,18}}
                ,new View() {CoordSys = new Plane(){Origin=new Origin(){x=2,y=0},Vector=0}, PartNums = new List<int> {7,8,9}}
                ,new View() {CoordSys = new Plane(){Origin=new Origin(){x=2,y=0},Vector=0}, PartNums = new List<int> {10,11,12}}
            };
    
            var viewsByGroup = views.GroupBy(p => p, new ViewComparer());
    
            foreach (var group in viewsByGroup)
            {
                foreach (var numList in group.Select(p => p.PartNums))
                    foreach (int num in numList)
                        Console.Write(num + ", ");
    
                Console.WriteLine();
            }
    
            Console.ReadLine();
        }
    }
    
    class ViewComparer : IEqualityComparer<View>
    {
        public bool Equals(View x, View y)
        {
            return x.CoordSys.Origin.x == y.CoordSys.Origin.x
                && x.CoordSys.Vector == y.CoordSys.Vector;
        }
    
        public int GetHashCode(View obj)
        {
            return obj.CoordSys.Origin.x.GetHashCode()
                ^ obj.CoordSys.Vector.GetHashCode();
        }
    }
