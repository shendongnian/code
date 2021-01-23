    class Instruction
    {
        public Instruction(Batch parent)
        {
            Parent = parent;
        }
        public Batch Parent { get; private set; }
        public string InstructionUID { get; set; } // Please start properties with an uppercase letter
    }
