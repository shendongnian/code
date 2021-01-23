    public override object ProvideValue(IServiceProvider serviceProvider)
            {
                var binding = new MultiBinding();
                binding.Bindings.Add(new Binding(pathOfWhatEverOne));
                binding.Bindings.Add(new Binding(pathOfWhatEverTwo));
                ...
                /*some code that involves this.name*/
                return binding.ProvideValue(serviceProvider);
            }
