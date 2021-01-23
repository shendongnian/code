    public override ProblemCollection Check(Member member)
    {
        Method method = member as Method;
        if (method == null)
        {
            return base.Check(member);
        }
        Console.WriteLine("Method: {0}", member.Name);
        InstructionCollection ops = method.Instructions;
        foreach (Instruction op in ops)
        {
            Console.WriteLine("File: {0}, Line: {1}, Pos: {2}, OpCode: {3}", op.SourceContext.FileName, op.SourceContext.StartLine, op.SourceContext.StartColumn, op.OpCode);
        }
        Console.WriteLine();
        return base.Problems;
    }
