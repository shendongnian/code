    class NotWorkingProgram  // no access modifier! Default is 'internal' {
        public class Deposit : Message
        ...
        public class AccountActor : Actor
        {
            public void Handle(Deposit message)
            ...
        } } 
