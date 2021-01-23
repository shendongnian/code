    public class EmpPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public override bool Equals(object obj)
        {
            EmpPerson cmp = (EmpPerson)obj;
            return ID.Equals(cmp.ID);
        }
    }
