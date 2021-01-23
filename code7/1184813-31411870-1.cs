    using System;
    using System.Collections;
    using System.Data.SqlClient;
    namespace TestProgram
    {
      public class Program
      {
        public static void Main(String[] args)
        {
          using (var connection = new SqlConnection("Server=(local);Database=my_database;Trusted_Connection=True;"))
          {
            connection.Open();
            try
            {
              var databases = connection.GetSchema("Databases");
            }
            catch (Exception ex)
            {
              Console.WriteLine(GetAllExceptionMessages(ex));
            }
          }
        }
        /* Recursively build a string of all nested exception data, stack traces
           and messages. */
        private static String GetAllExceptionMessages(Exception ex)
        {
          if (ex == null)
          {
            return "";
          }
          else
          {
            var nl = Environment.NewLine;
            var result = ex.Message + nl;
            foreach (DictionaryEntry de in ex.Data)
              result += String.Concat("  ", de.Key, ": ", de.Value, nl);
            /* StackTrace might be null when running this code in NUnit. */
            if (ex.StackTrace != null)
              result += String.Format("{0}Stack Trace:{0}{1}", nl, ex.StackTrace.ToString());
            return (String.Concat(result, nl, GetAllExceptionMessages(ex.InnerException))).Trim();
          }
        }
      }
    }
