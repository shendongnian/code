    public interface IClass1 {
        Class2 this[int index] { get; set; }
    }
    public class Class1 : IClass1 {
        private List<Class2> lstClass2 = new List<Class2>();
        public Class1() {
            for (int i = 0; i < 5; i++) lstClass2.Add(new Class2());
        }
        public Class2 this[int index] {
            get { return lstClass2[index]; }
            set { lstClass2[index] = value; }
        }
    }
