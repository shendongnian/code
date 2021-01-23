        public Connection(string name, Node a, Node b)
        {
            // ...
            this.AName = a.Name;
            // to keep these updated, there needs to be a binding between the two
            var binding = new Binding ("Name");
            binding.Source = this.NodeA;
            BindingOperations.SetBinding (this, ANameProperty, binding);
        }
