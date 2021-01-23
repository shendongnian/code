    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;
    
    namespace JsonDeserialize
    {
       class Program
       {
          static void Main(string[] args)
          {
             string test = 
                "{" +
                "    \"string_type\":\"test_string\",\n" +
                "    \"int_type\":42,\n" +
                "    \"float_type\":3.141592654,\n" + 
                "    \"bool_type\":true,\n" + 
                "    \"list_type\":[\n" +
                "        \"list_one\",\n" +
                "        \"list_two\"\n" +
                "    ],\n" +
                "    \"dict_type\":{\n" +
                "        \"dict_one\":\"dict_one\",\n" +
                "        \"dict_two\":\"dict_two\"\n" +
                "    }\n" +
                "}\n";
    
    
             var dict = new JavaScriptSerializer().Deserialize<
                Dictionary<string, object>>(test);
    
             string result_string = "";
             int result_int = 0;
             decimal result_float = 0.0M;
             bool result_bool = false;
             ArrayList result_list = new ArrayList();
             string result_list_one = "";
             string result_list_two = "";
             Dictionary<string, object> result_dict = new Dictionary<string,object>();
             string result_dict_one = "";
             string result_dict_two = "";
    
             if (dict.ContainsKey("string_type"))
             {
                result_string = (String)dict["string_type"];
             }
             if (dict.ContainsKey("int_type"))
             {
                result_int = (int)dict["int_type"];
             }
             if (dict.ContainsKey("float_type"))
             {
                result_float = (decimal)dict["float_type"];
             }
             if (dict.ContainsKey("bool_type"))
             {
                result_bool = (bool)dict["bool_type"];
             }
             if (dict.ContainsKey("list_type"))
             {
                result_list = (ArrayList)dict["list_type"];
                result_list_one = (String)result_list[0];
                result_list_two = (String)result_list[1];
             }
             if (dict.ContainsKey("dict_type"))
             {
                result_dict = (Dictionary<string,object>)dict["dict_type"];
                result_dict_one = (String)result_dict["dict_one"];
                result_dict_two = (String)result_dict["dict_two"];
             }
    
    
             ////////////////// TEST //////////////////
             // Below here is just a check of the data coming out
             string expected_string = "test_string";
             int expected_int = 42;
             decimal expected_float = 3.141592654M;
             bool expected_bool = true;
             string expected_list_one = "list_one";
             string expected_list_two = "list_two";
             string expected_dict_one = "dict_one";
             string expected_dict_two = "dict_two";
    
             Console.WriteLine("Results...");
             if (result_string == expected_string)
             {
                Console.WriteLine("String Passed");
             }
             else
             {
                Console.WriteLine("String Failed");
                Console.WriteLine("Result: " + result_string);
             }
    
             if (result_int == expected_int)
             {
                Console.WriteLine("Int Passed");
             }
             else
             {
                Console.WriteLine("Int Failed");
                Console.WriteLine("Result: " + result_int.ToString());
             }
    
             if (result_float == expected_float)
             {
                Console.WriteLine("Float Passed");
             }
             else
             {
                Console.WriteLine("Float Failed");
                Console.WriteLine("Result: " + result_float);
             }
    
             if (result_bool == expected_bool)
             {
                Console.WriteLine("Bool Passed");
             }
             else
             {
                Console.WriteLine("Bool Failed");
                Console.WriteLine("Result: " + result_bool);
             }
    
             if ((result_list_one == expected_list_one) &&
                (result_list_two == expected_list_two))
             {
                Console.WriteLine("List Passed");
             }
             else
             {
                Console.WriteLine("List Failed");
                Console.WriteLine("Result: " + result_list_one + " " + result_list_two);
             }
    
             if ((result_dict_one == expected_dict_one) &&
                (result_dict_two == expected_dict_two))
             {
                Console.WriteLine("Dict Passed");
             }
             else
             {
                Console.WriteLine("Dict Failed");
                Console.WriteLine("Result: " + result_dict_one + " " + result_dict_two);
             }
    
             Console.WriteLine("Test Complete");
          }
       }
    }
    
