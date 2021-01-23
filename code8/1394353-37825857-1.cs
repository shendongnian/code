    private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument XmlDocObj1 = new XmlDocument();
            XmlDocObj1.Load(AppDomain.CurrentDomain.BaseDirectory.ToString()+"test.xml");
            XmlNode rootnode1 = XmlDocObj1.SelectSingleNode("marina/dockone");
            XmlNode dockone = rootnode1.AppendChild(XmlDocObj1.CreateNode(XmlNodeType.Element, "slipone", ""));
            XmlNode docktwo = rootnode1.AppendChild(XmlDocObj1.CreateNode(XmlNodeType.Element, "sliptwo", ""));
            XmlNode dockthree = rootnode1.AppendChild(XmlDocObj1.CreateNode(XmlNodeType.Element, "slipthree", ""));
            //jsh: old logic
            //if (textBox1.Text != dockone.InnerText)
            //new logic to test whether we have already created the dockone node which should only occur once
            //you already have the logic for selecting the dockone node above...now just test if you already have it.
            //NOTE: you may actually want a switch statement given that you avhe dockone, docktwo, and dockthree or at least another 
            //      if statement to see if docktwo has been created and thus creaste dockthree.
            if (rootnode1 == null )
            {
                dockone.AppendChild(XmlDocObj1.CreateNode(XmlNodeType.Element, "Reg", "")).InnerText = textBox1.Text;
                XmlDocObj1.Save(AppDomain.CurrentDomain.BaseDirectory.ToString() + "test.xml");
            }
            //else if (textBox1.Text == dockone.InnerText) jsh: old logic
            else
            {
                docktwo.AppendChild(XmlDocObj1.CreateNode(XmlNodeType.Element, "Reg", "")).InnerText = textBox1.Text;
                XmlDocObj1.Save(AppDomain.CurrentDomain.BaseDirectory.ToString() + "test.xml");
            }
        }
