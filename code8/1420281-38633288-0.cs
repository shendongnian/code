    class Controller
    {
        public void MethodA()
        {
            OtherController.MethodB(); // This will work because MethodB is static
            // Like shown above you can call a static method from anywhere
        }
    }
    class OtherController
    {
        public static void MethodB() // <-- Notice "static"
        {
            // Do stuff
        }
    }
