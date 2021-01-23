        public class Unit
        {
            public string Name { get; set; }
            public Unit Parent { get; set; }
            public bool IsInCharge { get; set; }
            public Unit ParentUnitThatIsInCharge
            {
                get
                {
                    return GetParentUnitThatIsInCharge(this);
                }
            }
            public static Unit GetParentUnitThatIsInCharge(Unit unit)
            {
                Unit current = unit;
                while (!current.IsInCharge && current.Parent != null)
                {
                    current = current.Parent;
                }
                return current;
            }
        }
