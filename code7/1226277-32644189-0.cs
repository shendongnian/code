    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Reflection;
    using System.Security;
    namespace Eventing
    {
        public class ThisItem : MulticastNotifyPropertyChanged
        {
            void Test()
            {
            }
        
            String _name;
            public String name2
            {
                get {
                    return _name;
                }
                set
                {
                    _name = value;
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Invoke test #2");
                    Console.WriteLine("---------------------------");
                    Invoke(this, new PropertyChangedEventArgs("name"));
                }
            }
            public String name1
            {
                get {
                    return _name;
                }
                set
                {
                    _name = value;
    #if TESTINVOKE
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Invoke test #1");
                    Console.WriteLine("---------------------------");
                    InvokeFast(this, new PropertyChangedEventArgs("name"));
    #endif
                }
            }
        };
    
        class Program
        {
            static public BindingList<ThisItem> testList;
        
            static void Main(string[] args)
            {
                testList = new BindingList<ThisItem>();
                ThisItem t = new ThisItem();
                testList.ListChanged += testList_ListChanged;
                t.PropertyChanged += t_PropertyChanged;
                t.PropertyChanged += t_PropertyChanged2;
                testList.Add(t);
                t.name1 = "testing";
                Console.WriteLine("---------------------------");
                t.PropertyChanged -= t_PropertyChanged;
                t.PropertyChanged -= t_PropertyChanged2;
                t.PropertyChanged += t_PropertyChanged;
                testList.Add(t);
                t.PropertyChanged += t_PropertyChanged2;
                t.name2 = "testing";
            }
            static void testList_ListChanged(object sender, ListChangedEventArgs e)
            {
                Console.WriteLine("3) List changed: " + e.ListChangedType.ToString() + ((e.ListChangedType == ListChangedType.Reset) ? " (*** UPS! ***)": ""));
            }
            static void t_PropertyChanged2(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("2) t_PropertyChanged2: " + e.PropertyName);
            }
            static void t_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("1) t_PropertyChanged: " + e.PropertyName);
                testList.Remove((ThisItem)sender);
            }
        }
    }
