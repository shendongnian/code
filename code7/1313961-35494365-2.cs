    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
                
    namespace ClassLibrary1
    {
        public class ElementId
        {
            public string Name{set;get;}
        }
                
        public class TestClass
        {
            public static void TestMethod(ISet<ElementId> fSet)
            {
                MessageBox.Show("Number of Elements  in Set: " + fSet.Count.ToString());
                
                foreach(var lElement in fSet)
                {
                    MessageBox.Show(lElement.Name);
                }
            }
        }
    }
