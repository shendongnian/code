    using System;
    namespace Enumeration
     {
         using System;
         using System.Collections;
     // implements IEnumerable
     class ListBoxTest : IEnumerable
     {
         private string[] strings;
         private int ctr = 0;
         // private nested implementation of ListBoxEnumerator
         private class ListBoxEnumerator : IEnumerator
         {
             // member fields of the nested ListBoxEnumerator class
             private ListBoxTest currentListBox;
             private int index;
             // public within the private implementation
             // thus, private within ListBoxTest
             public ListBoxEnumerator(ListBoxTest currentListBox)
             {
                 // a particular ListBoxTest instance is
                 // passed in, hold a reference to it
                 // in the member variable currentListBox.
                 this.currentListBox = currentListBox;
                 index = -1;
             }
             // Increment the index and make sure the
             // value is valid
             public bool MoveNext()
             {
                 index++;
                 if (index >= currentListBox.strings.Length)
                     return false;
                 else
                     return true;
             }
             public void Reset()
             {
                 index = -1;
             }
             // Current property defined as the
             // last string added to the listbox
             public object Current
             {
                 get
                 {
                     return(currentListBox[index]);
                 }
             }
         }  // end nested class
         // Enumerable classes can return an enumerator
         public IEnumerator GetEnumerator()
         {
             return (IEnumerator) new ListBoxEnumerator(this);
         }
         // initialize the listbox with strings
         public ListBoxTest(params string[] initialStrings)
         {
             // allocate space for the strings
             strings = new String[8];
             // copy the strings passed in to the constructor
             foreach (string s in initialStrings)
             {
                 strings[ctr++] = s;
             }
         }
         // add a single string to the end of the listbox
         public void Add(string theString)
         {
             strings[ctr] = theString;
             ctr++;
         }
         // allow array-like access
         public string this[int index]
         {
             get
             {
                 if (index < 0 || index >= strings.Length)
                 {
                     // handle bad index
                 }
                 return strings[index];
             }
             set
             {
                 strings[index] = value;
             }
         }
         // publish how many strings you hold
         public int GetNumEntries()
         {
             return ctr;
         }
     }
    public class EnumerationTester
    {
       public void Run()
       {
           // create a new listbox and initialize
           ListBoxTest currentListBox =
               new ListBoxTest("Hello", "World");
           // add a few strings
           currentListBox.Add("Who");
           currentListBox.Add("Is");
           currentListBox.Add("John");
           currentListBox.Add("Galt");
           // test the access
           string subst = "Universe";
           currentListBox[1] = subst;
           // access all the strings
           foreach (string s in currentListBox)
           {
               Console.WriteLine("Value: {0}", s);
           }
       }
       [STAThread]
       static void Main()
       {
          EnumerationTester t = new EnumerationTester();
          t.Run();
       }
    }
 }
