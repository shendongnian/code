     using Sustem.Linq; // Add this line. 
                        //If it doesn't work add a reference to System.Core.dll
        
        namespace FormAppp
        {
            public class Form1 : Form
            {
                public Form1()
                {
                }
    
                ....
        
                void DoInitialization()
                {
                    listView1.Items.Add(new ListViewItem("1"));
                    listView1.Items.Add(new ListViewItem("2"));
                    listView1.Items.Add(new ListViewItem("3"));
        
        
                    listView2.Items.Add(new ListViewItem("1"));
                    listView2.Items.Add(new ListViewItem("3"));
        
                    var list1Source = listView1.Items.Cast<ListViewItem>();
                    var list2Source = listView2.Items.Cast<ListViewItem>();
    
                    var list3Source = list1Source.Where(x => 
                     list2Source.All(y => y.Text != x.Text));
                } 
            }
        }
        
