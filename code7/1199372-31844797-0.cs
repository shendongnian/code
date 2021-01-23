    namespace YourNamespace
    {
        using BCrypt = BCrypt.Net.BCrypt;
        class Program
        {
            static void Main(string[] args)
            {
                BCrypt.HashPassword("234");
            }
        }
