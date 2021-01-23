    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Resources;
    
    namespace ResourceDemo
    {
      internal class Program
      {
        private const string nameSpace = "ResourceDemo";
        private const string resourceExtension = ".resources";
        private const string resourceFilename = "StatusItems";
        private static IDictionary<string, StatusItem> dictionary;
    
        private static void Main(string[] args)
        {
          bool generateMode = false;
    
          if (generateMode) {
            // Only run when a new resource is added
            Generate();
          }
          else {
            // Show the contents of the resource
            EnumerateResource();
            
            // Make a dictionary so it is usable
            BuildDictionary();
    
            Console.WriteLine("Look-up items 2, 4, 42 and 3 in dictionary");
            WriteStatusItemToConsole(GetResource("2"));
            WriteStatusItemToConsole(GetResource("4"));
            WriteStatusItemToConsole(GetResource("42"));
            WriteStatusItemToConsole(GetResource("3"));
            Console.ReadKey();
          }
        }
    
        /// <summary>
        /// Build the working dictionary from the resource file
        /// </summary>
        public static void BuildDictionary()
        {
          Console.WriteLine("Building a look-up dictionary");
          StatusItem statusItem;
          dictionary = new Dictionary<string, StatusItem>();
          ResourceReader res = new ResourceReader(@".\" + resourceFilename + resourceExtension);
    
          IDictionaryEnumerator dict = res.GetEnumerator();
          while (dict.MoveNext()) {
            statusItem = (StatusItem)dict.Value;
            dictionary.Add(dict.Key.ToString(), statusItem);
          }
          res.Close();
          Console.WriteLine("{0} items written to dictionary.", dictionary.Count.ToString());
          Console.WriteLine();
        }
    
        /// <summary>
        /// List all the items inside the resource file. Assuming that the
        /// </summary>
        public static void EnumerateResource()
        {
          StatusItem statusItem;
          Console.WriteLine("Resources in {0}", resourceFilename + resourceExtension);
          ResourceReader res = new ResourceReader(@".\" + resourceFilename + resourceExtension);
          IDictionaryEnumerator dict = res.GetEnumerator();
          Console.WriteLine("Dictionary Enumeration ready");
          while (dict.MoveNext()) {
            statusItem = (StatusItem)dict.Value;
            Console.WriteLine("   {0}: '{1}, {2}' (Type: {3})", dict.Key, statusItem.Id.ToString(), statusItem.Message, dict.Value.GetType().Name);
          }
          res.Close();
          Console.WriteLine();
        }
    
        /// <summary>
        /// Called to create the binary resource file. Needs to be called once.
        /// </summary>
        public static void Generate()
        {
          StatusItem[] statusItem = new StatusItem[4];
    
          // Instantiate some StatusItem objects.
          statusItem[0] = new StatusItem(2, "File not found");
          statusItem[1] = new StatusItem(3, "Path not found");
          statusItem[2] = new StatusItem(4, "Too many open files");
          statusItem[3] = new StatusItem(5, "File access denied");
    
          // Define a resource file named StatusItems.resx.
          using (System.Resources.ResourceWriter rw = new ResourceWriter(@".\" + resourceFilename + resourceExtension)) {
            for (int i = 0; i < 4; i++) {
              rw.AddResource(statusItem[i].Id.ToString(), statusItem[i]);
            }
            rw.Generate();
          }
        }
    
        /// <summary>
        /// Look up StatusItem in dictionary with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static StatusItem GetResource(string key)
        {
          StatusItem result = null;
          if (dictionary != null) {
            dictionary.TryGetValue(key, out result);
          }
          return result;
        }
    
        /// <summary>
        /// Write the value of the given item to the console
        /// </summary>
        /// <param name="statusItem"></param>
        public static void WriteStatusItemToConsole(StatusItem statusItem)
        {
          if (statusItem != null) {
            Console.WriteLine("   Id: {0}  Message: {1}", statusItem.Id, statusItem.Message);
          }
          else {
            Console.WriteLine("Null Item");
          }
        }
    
        /// <summary>
        /// This is our sample class
        /// </summary>
        [Serializable()]
        public class StatusItem
        {
          public StatusItem(int id, string message)
          {
            Id = id;
            Message = message;
          }
    
          public int Id { get; set; }
          public string Message { get; set; }
        }
      }
    }
