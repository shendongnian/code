    using System;
    using System.Data;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                DataColumn article = new DataColumn("Article", typeof(string));
                dt.Columns.Add(article);
                DataColumn noun = new DataColumn("Noun", typeof(string));
                dt.Columns.Add(noun);
                DataColumn verb = new DataColumn("Verb", typeof(string));
                dt.Columns.Add(verb);
                DataRow dr = dt.NewRow();
                dr["Article"] = "the";
                dr["Noun"] = "boy";
                dr["Verb"] = "kick";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                DataRow dd = dt.NewRow();
                dd["Article"] = "a";
                dd["Noun"] = "ball";
                dd["Verb"] = "eat";
                dt.Rows.Add(dd);
                dd = dt.NewRow();
                string s = "the boy eat the ball"; //textBox1.Text;
                string[] st = s.Split(' ');
            
                foreach (var str in st)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        if(str == rows["Article"].ToString())
                            Console.WriteLine("Word=" + str + "    Column=Article");
                        else if (str == rows["Noun"].ToString())
                            Console.WriteLine("Word=" + str + "    Column=Noun");
                        else if (str == rows["Verb"].ToString())
                            Console.WriteLine("Word=" + str + "    Column=Verb");
                    }
                }
            }
        }
    }
