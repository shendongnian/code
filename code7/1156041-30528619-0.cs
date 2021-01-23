      using System;
      using System.Collections;
     using System.Collections.Generic;
     using System.IO;
     using System.Linq;
     using System.Runtime.Serialization;
     using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    namespace BinarySerializerExample
    {
    class Program
    {
        static void Main()
        {
            Serialize();
            Deserialize();
        }
        static void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            var people = new List<Person>();
            people.Add(new Person("Stack"));
            people.Add(new Person("Rewind"));
            // To serialize the hashtable and its key/value pairs,   
            // you must first open a stream for writing.  
            // In this case, use a file stream.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, people);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        static void Deserialize()
        {
            // Declare the hashtable reference.
            List<Person> people = null;
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                // Deserialize the hashtable from the file and  
                // assign the reference to the local variable.
                people = (List<Person>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            // To prove that the table deserialized correctly,  
            // display the key/value pairs. 
            foreach (var person in people)
            {
                Console.WriteLine(person.Name);
            }
        }
    }
    [Serializable]
    public class Person {
        public Person(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    }
