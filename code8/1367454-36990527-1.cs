       public virtual T AddControl <T>()
          where T : class, new(),IControl
       {
            //now you can create instance no reflection required
            var control = new T();
            this.Controls.Add(control);
            return control;
       }
       public void AddControl <T>(T control)
          where T : class, IControl
       {
       }
       public abstract void AddControl <T>(object[] constructorArgs)
          where T : class, IControl;
