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
                dt.Columns.Add("MENUID", typeof(int));
                dt.Columns.Add("MENUNAME", typeof(string));
                dt.Columns.Add("ACTIVE", typeof(string));
                dt.Columns.Add("PARENTID", typeof(int));
                dt.Columns.Add("ORDERNO", typeof(int));
                dt.Columns.Add("URL", typeof(string));
                dt.Columns.Add("APPLICATION_ID", typeof(string));
                dt.Columns.Add("ROLER_ID", typeof(int));
                dt.Rows.Add(new object[] { 11, "Feedback on System", "Y", 2, 2, "~ASPX/UserFeedBack.aspx", "Tester", 1 });
                dt.Rows.Add(new object[] { 3, "Reference Data", "Y", 0, 3, "Tester", 1 });
                dt.Rows.Add(new object[] { 26, "TAC", "Y", 3, 3, "Tester", 1 });
                dt.Rows.Add(new object[] { 27, "LAC", "Y", 3, 3, "Tester", 1 });
                List<DataRow> roots = dt.AsEnumerable().Where(x => dt.AsEnumerable().Where(y => x.Field<int?>("PARENTID") == y.Field<int?>("MENUID")).Count() == 0).ToList();
                treeView1.Nodes.Clear();
                foreach (DataRow row in roots)
                {
                    TreeNode node = treeView1.Nodes.Add(string.Join(" , ", row.ItemArray));
                    int id = row.Field<int>("MENUID");
                    GetChildren(dt, id, node);
                }
                treeView1.ExpandAll();
            }
            public void GetChildren(DataTable dt, int parentMenuId, TreeNode node)
            {
                List<DataRow> children = dt.AsEnumerable().Where(x => x.Field<int?>("PARENTID") == parentMenuId).ToList();
                foreach (DataRow child in children)
                {
                    TreeNode newNode = node.Nodes.Add(string.Join(" , ", child.ItemArray));
                    int id = child.Field<int>("MENUID"); 
                    GetChildren(dt, id, newNode);
                }
            }
        }
    }
    ​
