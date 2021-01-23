    public class ParentModel
        {
            public List<Model1> Child1 { get; set; }
            public List<Model2> Chil2 { get; set; }
            public ParentModel()
            {
                Child1 = new List<Model1>();
                Chil2 = new List<Model2>();
            }
        }
