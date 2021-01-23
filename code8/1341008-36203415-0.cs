    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    
    namespace TestStuff
    {
        class Program
        {
            //Input string should be of the form "<type>:<index>"
            static dynamic GiveMeSomethingDynamic(string someInput)
            {
                /* predefined arrays sothat we can return something */
                string[] _storedStrings = { "Word 1", "word 2", "word 3" };
                int[] _storedInts = { 1, 2, 3 };
                float[] _storedFloats = { 3.14f, 2.71f, 42.123f };
    
                /* Parse the input command (stringly typed functions are bad, I know.) */
                string[] splitted = someInput.Split(':');
                string wantedType = splitted[0];
                int index = int.Parse(splitted[1]);
    
                /* Decide what to return base on that argument */
                switch (wantedType)
                {
                    case "int":
                        return _storedInts[index];
                    case "string":
                        return _storedStrings[index];
                    case "float":
                        return _storedFloats[index];
    
                    //Nothing matched? return null
                    default:
                        return null;
                }
            }
    
            static void Main(string[] args)
            {
                /* get some return values */
                dynamic firstOutput = GiveMeSomethingDynamic("string:0");
                dynamic secondOutput = GiveMeSomethingDynamic("int:1");
                dynamic thirdOutput = GiveMeSomethingDynamic("float:2");
    
                /* Display the returned objects and their type using reflection */
                Console.WriteLine("Displaying returned objects.\n" +
                                  "Object 1: {0}\t(Type: {1})\n" +
                                  "Object 2: {2}\t\t(Type: {3})\n" +
                                  "Object 3: {4}\t\t(Type: {5})\n",
                                  firstOutput, firstOutput.GetType(),
                                  secondOutput, secondOutput.GetType(),
                                  thirdOutput, thirdOutput.GetType());
    
                /* Act on the type of a object. This works for *all* C# objects, not just dynamic ones. */
                if (firstOutput is string)
                {
                    //This was a string! Give it to a method which needs a string
                    var firstOutputString = firstOutput as string; //Cast it. the "as" casting returns null if it couldn't be casted.
                    Console.WriteLine("Detected string output.");
                    Console.WriteLine(firstOutputString.Substring(0, 4));
                }
    
                //Another test with reflection. 
                Console.WriteLine();
    
                //The list of objects we want to do something with
                string[] values = { "string:abcdef", "int:12", "float:3.14" };
                foreach(var value in values)
                {
                    /* Parse the type */
                    string[] parsed = value.Split(':');
                    string _type = parsed[0];
                    string _argument = parsed[1];
    
                    switch (_type)
                    {
                        case "string":
                            //This is a string.
                            string _stringArgument = _argument as string;
                            Method1(_stringArgument);
                            break;
                        case "int":
                            //Do something with this int
                            int _intArgument = int.Parse(_argument);
                            Method2(_intArgument);
                            break;
                        case "float":
                            float _floatArgument = float.Parse(_argument);
                            Method3(_floatArgument);
                            break;
    
                        default:
                            Console.WriteLine("Unrecognized value type \"{0}\"!", _type);
                            break;
                    }
    
                }
    
    
                Console.ReadLine();
            }
    
            public static void Method1(string s) => Console.WriteLine("String Function called with argument \"{0}\"", s);
            public static void Method2(int i) => Console.WriteLine("int Function called with argument {0}", i);
            public static void Method3(float f) => Console.WriteLine("float Function called with argument {0}", f);
        }
    }
