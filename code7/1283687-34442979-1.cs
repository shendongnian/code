    namespace A
    {
        public enum AE
        {
            AE_0,
            AE_1
        }
    
        public class DoSomething
        {
            public static void F<T>(T enumMember) where T : struct
            {
                // exit early if something other than enum entered
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T is not enum");
                }
    
                // Do whatever you need to do here
                Console.WriteLine(enumMember.ToString());
            }
        }
    }
    
    namespace B
    {
        public enum BE
        {
            BE_0,
            BE_1
        }
    }
    
    namespace C
    {
        public class Class1
        {
            public static void processEnum()
            {
                A.DoSomething.F<A.AE>(A.AE.AE_0);
                A.DoSomething.F<B.BE>(B.BE.BE_0);
            }
        }
    }
