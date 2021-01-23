    public class Test
    {
        public AssignableProperty<string> Variable1 { get; set; }
        public AssignableProperty<int> Variable2 { get; set; }
        public void Function()
        {
            if(Variable1.WasAssigned&&Variable2.WasAssigned)
                //do stuff
        }
    }
