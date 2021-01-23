      public Form1()
      {
          InitializeComponent();
    
          Person p = new Person();
    
          DynamicTypeDescriptor dt = new DynamicTypeDescriptor(typeof(Person));
          propertyGrid1.SelectedObject = dt.FromComponent(p);
      }
    
      private void button1_Click(object sender, EventArgs e)
      {
          DynamicTypeDescriptor dt = (DynamicTypeDescriptor)propertyGrid1.SelectedObject;
          DynamicTypeDescriptor.DynamicProperty dtp = (DynamicTypeDescriptor.DynamicProperty)dt.Properties["Age"];
    
          dtp.SetDisplayName("The age");
          dtp.SetDescription("Age of the person");
          dtp.SetCategory("Info");
    
          propertyGrid1.Refresh();
      }
