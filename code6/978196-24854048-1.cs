        public string NameInvoker()
        {
            if (InvokeRequired) 
            {
                return this.Invoke(new MethodInvokerWithStringResult(NamedMethod));
            } 
            else 
            {
               return lblName.Text;
            }
         }
         private string NamedMethod()
         {
              return lblName.Text;
         }
