       Task.Factory.StartNew(() =>
                {
                    if (!SimpleIoc.Default.ContainsCreated<MyViewModel>())
                        SimpleIoc.Default.Register<MyViewModel>();
                    ContainerViewModel.ContainerContent = SimpleIoc.Default.GetInstance<MyViewModel>();
                });
