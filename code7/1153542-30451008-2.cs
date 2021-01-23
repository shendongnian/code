     class Program
        {
            static void Main(string[] args)
            {
                ObjAssignStudy newInstance = new ObjAssignStudy();
             List<SD> sampleData=newInstance["c"];
            }
            public class SD
            {
                public string s { get; set; }
            }
    
            public class Obj
            {
                public string p { get; set; }
                public string u { get; set; }
                public List<SD> sD { get; set; }
            }
    
            public class ObjAssignStudy
            {
    
                private List<Obj> _ListObj= new List<Obj>();
                internal List<Obj> ListObj
                {
                    get { return _ListObj; }
                    set { _ListObj = value; }
                }
                List<SD> tempList = new List<SD>(); 
                public ObjAssignStudy()
                {
                    tempList.Add(new SD() { s = "EmptyList1" });
                    ListObj.Add(new Obj() { p = "a", sD = tempList, u = "B" });
                    tempList.Add(new SD() { s = "EmptyList2" });
                    ListObj.Add(new Obj() { p = "b", sD =tempList, u = "C" });
                    tempList.Add(new SD() { s = "EmptyList3" });
                    ListObj.Add(new Obj() { p = "c", sD =tempList, u = "D" });               
                }
                public List<SD> this[string index]
                {
                    get
                    {
                        foreach (Obj item in ListObj)
                        {
                            if (item.p == index)
                                return item.sD;
                        }
                        return new List<SD>();
                    }              
                }
            }
        }
