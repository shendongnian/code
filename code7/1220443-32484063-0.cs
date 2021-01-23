    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    
    namespace FileViewer
    {
        public partial class FileViewerForm : Form
        {
            public FileViewerForm()
            {
                InitializeComponent();
            }
    
            //Click handler.
            private void btnLoad_Click(object sender, EventArgs e)
            {
                //Ask them to select a file.
                openFileDialog.Title = "Please select a file";
                openFileDialog.Filter = "Any file|*.*";
                var dlgResult = openFileDialog.ShowDialog();
                if (dlgResult != DialogResult.OK)
                    return;
                richTextBox1.Clear();
    
                //Get the text as a char array.
                char[] text = File.ReadAllText(openFileDialog.FileName).ToCharArray();
    
                //loop through all of them
                for (int i = 0; i < text.Length; i++)
                {
                    //is this a special ASCII character?
                    if (lSpecialDict.ContainsKey(text[i]))
                    {
                        string replacement;
                        //get the replacement
                        lSpecialDict.TryGetValue(text[i], out replacement);
                        if (replacement != null)
                            //Print it out with DarkGray as backcolor, Firebrick as font color.
                            richTextBox1.AppendText("[" + replacement + "]", Color.LightGray, Color.Firebrick);
                    }
                    //just a normal character? Then append it.
                    else
                        richTextBox1.AppendText(text[i].ToString());
                }
            }
    
            //Contains the substition strings for the characters. A char --> string mapping.
            private Dictionary<char, string> lSpecialDict 
                = new Dictionary<char, string>()
            {
                { '\0',      "NUL" }, {(char)0x01, "SOH" }, {(char)0x02, "STX" },
                {(char)0x03, "ETX" }, {(char)0x04, "EOT" }, {(char)0x05, "ENQ" },
                {(char)0x06, "ACK" }, {(char)0x07, "BEL" }, {(char)0x08, "BS"  },
                {(char)0x09, "HT"  }, {(char)0x0A, "LF"  }, {(char)0x0B, "VT"  },
                {(char)0x0C, "FF"  }, {(char)0x0D, "CR"  }, {(char)0x0E, "SO"  },
                {(char)0x0F, "SI"  }, {(char)0x10, "DLE" }, {(char)0x11, "DC1" },
                {(char)0x12, "DC2" }, {(char)0x13, "DC3" }, {(char)0x14, "DC4" },
                {(char)0x15, "NAK" }, {(char)0x16, "SYN" }, {(char)0x17, "ETB" },
                {(char)0x18, "CAN" }, {(char)0x19, "EM"  }, {(char)0x1A, "SUB" },
                {(char)0x1B, "ESC" }, {(char)0x1C, "FS"  }, {(char)0x1D, "GS"  },
                {(char)0x1E, "RS"  }, {(char)0x1F, "US"  }, {(char)0x7F, "DEL" },
            };
    
            private void FileViewerForm_Load(object sender, EventArgs e)
            {
    
            }
        }
        public static class RichTextBoxExtensions
        {
            public static void AppendText(this RichTextBox box, string text, System.Drawing.Color bgcolor, Color fontcolor)
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
    
                var saved = box.SelectionBackColor;
                var saved2 = box.SelectionColor;
                box.SelectionBackColor = bgcolor;
                box.SelectionColor = fontcolor;
                box.AppendText(text);
                box.SelectionBackColor = saved;
                box.SelectionColor = saved2;
            }
        }
    }
