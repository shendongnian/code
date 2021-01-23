    public abstract class Employee
    {
    }
    public sealed class Ceo: Employee
    {
    }
    public abstract class Programmer: Employee
    {
    }
    public sealed class JavaProgrammer: Programmer
    {
    }
    public sealed class IosProgrammer: Programmer
    {
    }
    public sealed class Janitor: Employee
    {
    }
    public static class ProgrammerFactory
    {
        public static Programmer NewJavaProgrammer()
        {
            return new JavaProgrammer();
        }
        public static Programmer NewIosProgrammer()
        {
            return new IosProgrammer();
        }
    }
    public static class CeoFactory
    {
        public static Ceo NewCeo()
        {
            return new Ceo();
        }
    }
    public static class JanitorFactory
    {
        public static Janitor NewJanitor()
        {
            return new Janitor();
        }
    }
