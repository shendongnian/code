    public class MyClass {
        DatabaseCollaborator collaborator;
        public MyClass(DatabaseCollaborator collaborator) {
            this.collaborator = collaborator;
        }
        public void DoSomething() {
            //Some code which depends on the database tables being created
            collaborator.someMethod();
        }
        public void DoSomethingElse() {
            //Some other code which depends on the database tables being created
            collaborator.anotherMethod();
        }
    }
    public class DatabaseCollaborator {
        DatabaseConfig config;
        public DatabaseCollaborator(DatabaseConfig config) {
            this.config = config;
        }
        public void someMethod() {
        }
        public void anotherMethod() {
        }
    }
    public class DatabaseConfig {
        public DatabaseConfig() {
            // initialize
        }
    }
