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
                InitializeComponent();
                DataTable dt = new DataTable();
                treeView1.Nodes.Clear();
                DataTable dtRoot = this.GetData(0);
                TreeNode node = treeView1.Nodes.Add(string.Join(" , ",  dtRoot.Rows[0].ItemArray));
                int id = dtRoot.Rows[0].Field<int>("MENUID");
                GetChildren(dt, id, node);
                treeView1.ExpandAll();
            }
            public void GetChildren(DataTable dt, int parentMenuId, TreeNode node)
            {
                DataTable dt = this.GetData(int.Parse(parentMenuId));
                foreach (DataRow child in dt.AsEnumerable())
                {
                    TreeNode newNode = node.Nodes.Add(string.Join(" , ", child.ItemArray));
                    int id = child.Field<int>("MENUID"); 
                    GetChildren(dt, id, newNode);
                }
            }
        }
    }
    ​
