        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
                {
                    return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
    //Get all types
                    Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "loopClasses");
                    for (int i = 0; i < typelist.Length; i++)
                    {//Loop on them 
                        if (typelist[i].BaseType == typeof(System.Windows.Forms.Form) && typelist[i].Name == textbox.text)
                        {//if windows form and the name is match
    
    //Create Instance and show it
                            Form tmp =(Form) Activator.CreateInstance(typelist[i]);
                            //MessageBox.Show(typelist[i].Name);
                            tmp.Show();
                        }
                    }
        
                }
