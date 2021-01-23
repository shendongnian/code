	public class Invoice
    {
        public int Id_record { get; private set; }
        public EmployeeID EmployeeID { get; private set; }
    }
	
	public struct EmployeeID {
        // as per Eric Lippert's suggestion
        public EmployeeID(int id) {
            Value = id;
        }
		public int Value { get; private set; }
		public override string ToString() {
			return $"EmployeeID: {Value}";
		}
	}
	
