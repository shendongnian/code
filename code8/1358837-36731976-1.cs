    using NUnit.Framework.Internal;
    using NUnit.Framework.Internal.Commands;
    using NUnit.Framework.Internal.Execution;
    
    TestActionCommand command = new TestActionCommand(CommandBuilder.MakeTestCommand(TestExecutionContext.CurrentContext.CurrentTest as TestMethod));
    command.Execute(TestExecutionContext.CurrentContext);
