    public Form1()
    {
        if(File.Exists("soldier.csv"))
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("soldier.csv"))
			{
				string stream_line;
				int intCommaIndex1 = 0;
				int intCommaIndex2;
				string strSubStringSect;
				while (!sr.EndOfStream)
				{
					stream_line = sr.ReadLine();
					intCommaIndex1 = stream_line.IndexOf(",", intCommaIndex1);
					intCommaIndex2 = stream_line.IndexOf(",", intCommaIndex1);
					strSubStringSect = stream_line.Substring(intCommaIndex1, intCommaIndex2);
					richTextBox1.Text = richTextBox1.Text + " " + strSubStringSect;
					intCommaIndex1 = intCommaIndex2;
				}
			}
        }
    }
