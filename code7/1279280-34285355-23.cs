    [Theory, AutoData]
    public void Should_throw_argument_exception_when_the_input_strings_are_invalid(
        ValidatesTheStringArguments assertion)
    {
        var sut = typeof(SystemUnderTest).GetMethod("SomeMethod");
    
        assertion.Verify(sut);
    }
    
    public class ValidatesTheStringArguments : GuardClauseAssertion
    {
        public ValidatesTheStringArguments(ISpecimenBuilder builder)
            : base(
                  builder,
                  new CompositeBehaviorExpectation(
                      new NullReferenceBehaviorExpectation(),
                      new EmptyStringBehaviorExpectation(),
                      new WhitespaceOnlyStringBehaviorExpectation()))
        {
        }
    }
    
    public class EmptyStringBehaviorExpectation : IBehaviorExpectation
    {
        public void Verify(IGuardClauseCommand command)
        {
            if (!command.RequestedType.IsClass
                && !command.RequestedType.IsInterface)
            {
                return;
            }
    
            try
            {
                command.Execute(string.Empty);
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (Exception e)
            {
                throw command.CreateException("empty", e);
            }
    
            throw command.CreateException("empty");
        }
    }
    
    public class WhitespaceOnlyStringBehaviorExpectation : IBehaviorExpectation
    {
        public void Verify(IGuardClauseCommand command)
        {
            if (!command.RequestedType.IsClass
                && !command.RequestedType.IsInterface)
            {
                return;
            }
    
            try
            {
                command.Execute(" ");
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (Exception e)
            {
                throw command.CreateException("whitespace", e);
            }
    
            throw command.CreateException("whitespace");
        }
    }
