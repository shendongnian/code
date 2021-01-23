    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                int l_Index = 0;
    
                InitializeComponent();
    
                MenuItem[] l_MenuItems = new MenuItem[3];
    
                for (l_Index = 0; l_Index < l_MenuItems.Length; l_Index++)
                {
                    l_MenuItems[l_Index] = new MenuItem("Menu " + l_Index.ToString(), MenuItem_Click);
                }
    
                System.Windows.Forms.ContextMenu l_ContextMenu = new ContextMenu(l_MenuItems);
    
                dataGridView1.ContextMenu = l_ContextMenu;
            }
    
            private void MenuItem_Click(object sender, EventArgs e)
            {
                MenuItem l_MenuItem = sender as MenuItem;
    
                if (l_MenuItem != null)
                {
                    System.Windows.Forms.ContextMenu l_ContextMenu = l_MenuItem.GetContextMenu();
    
                    if (l_ContextMenu != null)
                    {
                        if (l_ContextMenu.SourceControl != null)
                        {
                            System.Diagnostics.Debug.WriteLine(l_ContextMenu.SourceControl.Name);
                        }
                    }
                }
            }
    
            private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView1.ContextMenu.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }
    }
