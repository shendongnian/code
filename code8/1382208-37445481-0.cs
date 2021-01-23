    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace treeviewSort
    {
        internal class Program
        {
            public class comp_list : IComparer<string>
            {
                public Stopwatch sw = new Stopwatch();
                public int CompareCount = 0;
                public int Compare(string xx, string yy)
                {
                    ++CompareCount;
                    sw.Start();
                    string x = xx.ToString();
                    string y = yy.ToString();
                    sw.Stop();
                    return x.CompareTo(y);
                }
            }
    
            public class comp_tree : IComparer
            {
                public Stopwatch sw = new Stopwatch();
                public int CompareCount = 0;
                public int Compare(object xx, object yy)
                {
                    ++CompareCount;
                    sw.Start();
                    string x = xx.ToString();
                    string y = yy.ToString();
                    sw.Stop();
                    return x.CompareTo(y);
                }
            }
    
    
            private static void Main()
            {
                DoThisTwice();
                DoThisTwice();
                Console.ReadLine();
            }
    
            private static void DoThisTwice()
            {
                List<string> MyList = new List<string>();
                TreeView tv = new TreeView();
    
                int Cnt = 10000;
                string s = "";
                Random R = new Random();
                for (int i = 0; i < Cnt; i++)
                {
                    s = (R.Next(0, Cnt)).ToString();
                    MyList.Add(s);
                    tv.Nodes.Add(s);
                }
    
                Stopwatch t = new Stopwatch();
                t.Start();
                comp_list cmp = new comp_list();
                MyList.Sort(cmp);
                t.Stop();
                Console.WriteLine("SORT_LIST={0}. Comparisons={1}. Compare time={2}", t.ElapsedMilliseconds, cmp.CompareCount, cmp.sw.ElapsedMilliseconds);
    
                var tvcmp = new comp_tree();
                tv.TreeViewNodeSorter = tvcmp;
                Stopwatch tt = new Stopwatch();
                tt.Start();
                tv.Sort();
                tt.Stop();
                Console.WriteLine("SORT_TREE={0} Comparisons={1}. Compare time={2}", tt.ElapsedMilliseconds, tvcmp.CompareCount, tvcmp.sw.ElapsedMilliseconds);
            }
        }
    }
