    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace ConsoleApplication1
    {
        class Program
        {
            class Process
            {
                public int ProcessId { get; set; }
                public string FilePath { get; set; }
                public string FileName { get; set; }
                public string User { get; set; }
            }
            static void Main(string[] args)
            {
                Process p1 = new Process();
                p1.ProcessId = 1;
                p1.FileName = "Tool.exe";
                p1.FilePath = @"C:\Tool.exe";
                p1.User = "User1";
                Process p2 = new Process();
                p2.ProcessId = 2;
                p2.FileName = "Tool2.exe";
                p2.FilePath = @"C:\Tool2.exe";
                p2.User = "User2";
                Process p3 = new Process();
                p3.ProcessId = 3;
                p3.FileName = "Tool3.exe";
                p3.FilePath = @"C:\Tool3.exe";
                p3.User = "User3";
                ListBox listBox = new ListBox();
                listBox.Items.Add(p1);
                listBox.Items.Add(p2);
                listBox.Items.Add(p3);
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    Process p = (Process)listBox.Items[i]; //Access the value of the item
                    Console.WriteLine("Process id: {0}", p.ProcessId);
                    Console.WriteLine("Process filename: {0}", p.FileName);
                    Console.WriteLine("Process file path: {0}", p.FilePath);
                    Console.WriteLine("Process user: {0}", p.User);
                }
                Console.ReadLine();
            }
        }
    }
