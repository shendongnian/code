    public class OrderAttribute : Attribute
    {
        public int priority;
        public OrderAttribute(int priority)
        {
            this.priority = priority;
        }
    }
    public enum Test
    {
        [Order(1)] value1 = 1,
        [Order(2)] value2 = 2,
        [Order(0)] value3 = 3
    }
    private static void Main(string[] args)
        {
            Dictionary<string, int> priorityTable = new Dictionary<string, int>();
            
            var values = Enum.GetValues(typeof (Test)).Cast<Test>();
            MemberInfo[] members = typeof (Test).GetMembers();
            foreach (MemberInfo member in members)
            {
                object[] attrs = member.GetCustomAttributes(typeof(OrderAttribute), false);
                foreach (object attr in attrs)
                {
                    OrderAttribute orderAttr = attr as OrderAttribute;
                    if (orderAttr != null)
                    {
                        string propName = member.Name;
                        int priority = orderAttr.priority;
                        priorityTable.Add(propName, priority);
                    }
                }
            }
            values = values.OrderBy(n => priorityTable[n.ToString("G")]);
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }
