    namespace trial1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                employeename emp1 = new employeename("Joe");
                employeename emp2 = p.InstanceEqual();
            }
            public employeename InstanceEqual()
            {
                string name = "Unnikrishnan";
                employeename emp2 = new employeename(name);
				return emp2;
            }
        }
        public class employeename
        {
            string _name;
            public employeename(string name)
            {
                _name = name;
            }
        }
    }
