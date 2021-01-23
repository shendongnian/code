        private void Form1_Load(object sender, EventArgs e)
        {
            //ComboBox will use "Name" property of the items you add
            comboBox1.DisplayMember = "Name";
            //Create the reader for your resx file
            ResXResourceReader reader = new ResXResourceReader("C:\\your\\file.resx");
            //Set property to use ResXDataNodes in object ([see MSDN][2])
            reader.UseResXDataNodes = true;
            IDictionaryEnumerator enumerator = reader.GetEnumerator();
            while (enumerator.MoveNext())
            {   //Fill the combobox with all key/value pairs
                comboBox1.Items.Add(enumerator.Value);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            //Assembly is used to read resource value
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            //Current resource selected in ComboBox
            ResXDataNode node = (ResXDataNode)comboBox1.SelectedItem;
            //textBox2 contains the resource comment
            textBox2.Text = node.Comment;
            //Reading resource value, you can probably find a smarter way to achieve this, but I don't know it
            object value = node.GetValue(new AssemblyName[] { currentAssembly.GetName() });
            if (value.GetType() != typeof(String))
            {   //Resource isn't of string type
                textBox1.Text = "";
                return;
            }
            //Writing string value in textBox1
            textBox1.Text = (String)value;
        }
