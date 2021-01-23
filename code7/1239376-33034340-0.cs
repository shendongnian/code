    void InitBinding() {
        Address bindingSource = ...
        String[] paths = new String[] { "Street", "City", etc... };
        foreach(TextBox textBox in ...) {
            String path = ...  // get the path for this textbox
            Binding binding = new Binding( path );
            binding.Source = bindingSource;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding( textBox, TextBox.TextProperty, binding );
        }
    }
