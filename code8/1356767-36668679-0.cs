	var thread = new Thread(() =>
							{
								SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
								Window window = new Window();
								View view = new View();
								ViewModel viewModel = new ViewModel();
								window.Content = view;
								
								// When the window closes, shut down the dispatcher
								window.Closed += (s, args) =>
													 Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
								window.Show();
								// Start the Dispatcher Processing
								Dispatcher.Run();
							});
	thread.SetApartmentState(ApartmentState.STA);
	thread.Start();
