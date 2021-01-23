     public override object ProvideValue(IServiceProvider serviceProvider)
        {
           IProvideValueTarget ipvt = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
           if (ipvt.TargetObject is DependencyObject && System.ComponentModel.DesignerProperties.GetIsInDesignMode((DependencyObject)ipvt.TargetObject) == true)
                    return "No designer mode please !";
            MessageBox.Show("ProvideValue called while running !");
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TermineDB;Integrated Security=True;Persist Security Info=True";
        }
