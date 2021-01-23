    using NUnit.Framework.Internal;
    using NUnit.Framework.Internal.Commands;
    using NUnit.Framework.Internal.Execution;
    
    TestCommand command = new TestActionCommand(CommandBuilder.MakeTestCommand(new TestMethod(TestExecutionContext.CurrentContext.CurrentTest.Method)));
                command.Execute(TestExecutionContext.CurrentContext);
