      public MyClass: IActivable {
        private Boolean m_IsActive;
    
        private void CoreActivate() {...};
        private void CoreDeActivate() {...};
    
        public Boolean IsActive {
          get {
            return m_IsActive; 
          }
          set {
            if (value != m_IsActive) {
              if (value) 
                CoreActivate();
              else 
                CoreDeActivate();
    
              m_IsActive = value;
            } 
          }
        }
      }
...
      MyClass sample = new MyClass();
      
      // or (if you implement the extension method) you can put it
      // sample.Activate();
      sample.IsActive = true; // activate
      ...
      sample.IsActive = false; // deactivate
