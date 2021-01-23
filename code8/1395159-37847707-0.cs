    class Foo {}
    class Command
    {
        public Foo Add() { return new Foo(); }
    }
    static class ExtensionMethods
    {
        public static int Bar(this Foo foo) { return 1; }
    }
