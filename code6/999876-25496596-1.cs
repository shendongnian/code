        public static ComboBox ComboFill()
                 {
                     ComboBox xx = new ComboBox();
                     ArrayList ColorList = new ArrayList();
                     Type colorType = typeof(System.Drawing.Color);
                     PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
                     foreach (PropertyInfo c in propInfoList)
                     {
                         xx.Items.Add(c.Name);
                     }
                     return xx;
                 }
               private Color colorfill1 = Color.Tomato;
               private Color colorfill2 = Color.Tomato;
               private ComboBox x1=ComboFill();
               private ComboBox x2=ComboFill();
        
         public ComboBox ChooseColor1 {
        
                get { return x1; }
                set { x1=value; OnPaint(null); }
        
            }
         public ComboBox ChooseColor2 {
        
                get { return x2; }
                set { x2=value; OnPaint(null); }
        
            }
    
         protected override void OnPaint(PaintEventArgs e)
                {
                        //my functions
    //something with colorfill1
    //something with colorfill2
                        
                   
                }
