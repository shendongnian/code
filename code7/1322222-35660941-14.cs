            services.AddMvc().AddMvcOptions(options =>
            {
                options.ModelBinders.Clear();
                options.ModelBinders.Add(new IoCModelBinder());
            });
