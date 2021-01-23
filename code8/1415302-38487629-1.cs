    public class ParentInstructionRelation
    {
        Batch Parent {get;private set;}
        Instruction Instruction {get;private set;}
        
        public ParentInstructionRelation(Batch parent, Instruction instruction)
        {
            Parent = parent;
            Instruction = instruction;
        }
    }
